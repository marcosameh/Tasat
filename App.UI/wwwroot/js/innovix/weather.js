(function () {

    //Angular implemntation of the weather widget.
    angular.module("weatherApp", [])
        .controller("weatherController", ["$scope", "$http", function ($scope, $http) {

            $scope.getWeather = function () {

                //Get weather from http://worldweatheronline.com
                //On error use console to log error.
                //on success populate the scope weather object with new instance of the weather function.
                $http.get('http://api.worldweatheronline.com/free/v2/weather.ashx?q=' + $scope.city + '&format=' + $scope.format + '&num_of_days=' + $scope.daysCount + '&key=' + $scope.apikey)
                    .success(function (response) {
                        var data = response.data;
                        var current = data.current_condition[0];

                        $scope.weather = new Weather(current.FeelsLikeC, current.humidity,
                            current.temp_C, current.weatherDesc[0].value, current.weatherIconUrl[0].value, current.winddirPoint,
                            current.winddirDegree, current.windspeedKmph, current.windspeedMiles);

                        if (data.weather && data.weather.length > 0) {
                            $(data.weather).each(function () {
                                var forcast = this;
                                $scope.weather.forcast.push(new Forcast(forcast.date, forcast.hourly[0].weatherIconUrl[0].value,
                                    forcast.hourly[0].weatherDesc[0].value, forcast.maxtempC));
                            });
                        }
                    })
                    .error(function (response) {
                        console.log(response);
                    });

                //Call custom web api controller in weather controller to get additional Info like water temp and tips
                if ($scope.additionalInfo) {

                    var url;
                    if ($scope.languageId) {
                        url = "/api/weather/getinfo?location=" + $scope.city + "&languageId=" + $scope.languageId;
                    }
                    else {
                        url = "/api/weather/getinfo?location=" + $scope.city + "&languageId=";
                    }
                    $http.get(url)
                        .success(function (response) {
                            $scope.info = response;
                        })
                        .error(function (response) {
                            console.log(response);
                        });
                }
            }

        }])
        .directive('weather', [function () {

            function link(scope, element, attrs) {
                var self = $(element)

                scope.apikey = self.data("api-key");
                scope.daysCount = self.data("days-count");
                scope.city = self.data("default-city");
                scope.additionalInfo = self.data("additional-info");
                scope.format = "json";
                scope.languageId = self.data("language-id")

                scope.getWeather();
            }

            return {
                restrict: 'E',
                link: link
            };
        }]);
    //boostrap the ng-app manually to avoid collision with other existing ng-apps in the conatiner page
    angular.bootstrap(document.getElementById("weatherGadget"), ['weatherApp']);

}());

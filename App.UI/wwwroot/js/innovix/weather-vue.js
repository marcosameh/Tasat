//Vue implemntation of the weather widget.
//Get weather from https://openweathermap.org
//On error use console to log error.
//on success populate the scope weather object with new instance of the weather function.
new Vue({
  el: "#weather-div",
  data: {
    apiKey: "",
    airTemp: 0,
    windSpeed: 0,
    imageFullPath: "",
    cityId: "",
    languageId: "",
    iconPackName: "",
  },
  mounted: function mounted() {
    this.apiKey = this.$refs.weatherSetup.dataset.apiKey;
    this.iconPackName = this.$refs.weatherSetup.dataset.iconPack;
    this.languageId = this.$refs.weatherSetup.languageId;
    this.cityId = this.$refs.weatherSetup.dataset.cityId;
    this.fetchWeather();
  },
  methods: {
    fetchWeather: function () {
      var vi = this;
      var d = new Date();
      var dataKey = d.getFullYear() + "/" + d.getMonth() + "/" + d.getDate();
      var dateKeySpeed = dataKey + "Speed";
      var dateKeyTemp = dataKey + "Temp";
      var storedTemp = localStorage.getItem(dateKeyTemp);

      if (!storedTemp) {
        axios
          .get("https://api.openweathermap.org/data/2.5/weather?id=" + this.cityId + "&appid=" + this.apiKey + "&units=metric")
          .then(function (response) {
            var data = response.data;
            vi.airTemp = Math.round(data.main.temp);
            vi.windSpeed = Math.round(data.wind.speed);
            vi.imageFullPath = "/images/weather icon packs/" + vi.iconPackName + "/" + data.weather[0].icon + ".png";

            localStorage.setItem(dateKeyTemp, vi.airTemp);
            localStorage.setItem(dateKeySpeed, vi.windSpeed);
            localStorage.setItem(vi.iconPackName, vi.imageFullPath);
          })
          .catch(function (error) {
            console.log(error);
          });
      } else {
        vi.airTemp = storedTemp;
        vi.windSpeed = localStorage.getItem(dateKeySpeed);
        vi.imageFullPath = localStorage.getItem(vi.iconPackName);
      }
    },
  },
});

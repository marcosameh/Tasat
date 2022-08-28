var app = function () {
    var self = this;
    var pageSize = 50;


    var initilaizeSummerNote = function () {
        var summerNoteElements = $("textarea.summernoteEditor");
        if (summerNoteElements.length > 0) {
            //Add Css File
            $('head').append('<link rel="stylesheet" href="/content/plugins/summernote.css" type="text/css" />');
            //init summer note
            summerNoteElements.each(function () {
                var self = $(this);
                setupSummernote(self);
            });
        }
    };

    var initilaizePrettyPhoto = function () {
        var photoElements = $(".photo");
        if (photoElements.length > 0) {
            //Add Css File
            $('head').append('<link rel="stylesheet" href="/content/plugins/prettyPhoto.css" type="text/css" />');
            //init summer note
            photoElements.each(function () {
                var self = $(this);
                self.prettyPhoto({ social_tools: '' });
            });
        };
    };

    var initilaizePageNameValidation = function () {
        var pageNameElements = $(".pageName");
        if (pageNameElements.length > 0) {
            pageNameElements.each(function () {
                var self = $(this);
                self.bind("blur", function () {
                    validatePageName(self);
                });
            });
        };
    };

    var initilaizeDataTables = function () {
        var tableElements = $("table.dataTable");
        if (tableElements.length > 0) {

            tableElements.each(function () {
                var self = $(this);
                self.DataTable({
                    responsive: true,
                    "pageLength": pageSize,
                    "lengthMenu": [[10, 25, 50, 100, 200, 500, -1], [10, 25, 50, 100, 200, 500, "All"]],
                    "columnDefs": [
                        { "orderable": false, "targets": 0 }
                    ]
                });

                $('div.dataTables_length select').removeClass('form-control input-sm');
                $('div.dataTables_length select').css({ width: '60px' });
                $('div.dataTables_length select').select2({
                    minimumResultsForSearch: -1
                });

            });

            //require([

            //    "/scripts/plugins/select2.min.js"
            //], );
        };
    };

    var initilaizeDatePicker = function () {
        var datepickerElements = $(".hasDatepicker");
        if (datepickerElements.length > 0) {
            //Add Css File
            $('head').append('<link rel="stylesheet" href="/content/plugins/zebra.css" type="text/css" />');
            //init DatePicker
            datepickerElements.each(function () {
                var self = $(this);
                self.Zebra_DatePicker({
                    format: 'd-m-Y',
                    default_position: 'below',
                    show_icon: false
                });

                var datepicker = self.data('Zebra_DatePicker');
                self.next(".input-group-addon").bind("click", function () {
                    datepicker.show();
                });
            });
        };
    };

    var initilaizeGoogleMaps = function () {
        var googleMapElements = $(".googleMap");
        if (googleMapElements.length > 0) {
            //init googel maps
            googleMapElements.each(function () {
                var self = $(this);

                var parentContainer = self.closest("div.mapContainer");
                var txtLat = parentContainer.find(".txtLatitude");
                var txtLng = parentContainer.find(".txtLongitude");
                var txtZoom = parentContainer.find(".txtZoomLevel");
                var hidLatitude = parentContainer.find(".hidLatitude");
                var hidLongitude = parentContainer.find(".hidLongitude");
                var txtAddress = parentContainer.find(".txtAddress");
                var btnReset = parentContainer.find(".btnClear");

                initializeGoogleMap(self, txtLat, txtLng, txtZoom, hidLatitude, hidLongitude);
                initializeAddress(txtAddress, txtLat, txtLng, hidLatitude, hidLongitude);
                handelDragEvent(txtAddress, txtLat, txtLng, hidLatitude, hidLongitude);
                //handelResetMap(btnReset, txtAddress, txtLat, txtLng, hidLatitude, hidLongitude, txtZoom);

            });
        };
    }

    var initilaizeXEditable = function (url, onSave) {
        var editableElements = $(".editable");
        if (editableElements.length > 0) {
            editableElements.each(function () {
                var self = $(this);

                self.editable({
                    url: url,
                    params: function (params) {
                        return {
                            FilePath: $(self).data("file-path"),
                            Key: $(self).data("key"),
                            Value: params.value,
                        };
                    },
                    mode: "inline",
                    send: 'always'
                }).on('save', onSave);

            });
        };
    }

    var initilaizeTreeView = function () {
        var treeviewElements = $(".tree-view");
        if (treeviewElements.length > 0) {
            //Add Css File
            $('head').append('<link rel="stylesheet" href="/content/plugins/jstree/style.min.css" type="text/css" />');
            //init DatePicker
            treeviewElements.each(function () {
                var self = $(this);
                self.jstree({
                    "core": {
                        "multiple": false,
                        "themes": {
                            "responsive": true
                        }
                    },
                    "types": {
                        "default": {
                            "icon": "fa fa-folder icon-state-warning icon-lg"
                        },
                        "file": {
                            "icon": "fa fa-file icon-state-default icon-lg"
                        }
                    },
                    "plugins": ["types"]
                }).on('select_node.jstree', function (e, data) {
                    var link = $('#' + data.selected).find('a');
                    if (link.attr("href") != "#" && link.attr("href") != "javascript:;" && link.attr("href") != "") {
                        window.location.href = link.attr("href");
                        return false;
                    }
                });;
            });
        }
    };

    return {
        init: function () {
            initilaizeSummerNote();
            initilaizeGoogleMaps();
            initilaizePageNameValidation();
            initilaizeDatePicker();
            initilaizeDataTables();
            initilaizePrettyPhoto();
        },
        initSummerNote: initilaizeSummerNote,
        initGoogleMaps: initilaizeGoogleMaps,
        initPageNameValidation: initilaizePageNameValidation,
        initDatePicker: initilaizeDatePicker,
        initDataTables: initilaizeDataTables,
        initTreeView: initilaizeTreeView,
        initXEditable: initilaizeXEditable,
        initPrettyPhoto: initilaizePrettyPhoto
    };
};

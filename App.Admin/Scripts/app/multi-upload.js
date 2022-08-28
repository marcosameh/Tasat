$(document).ready(function () {
    Dropzone.autoDiscover = false;
    var propJson = $("#hdnJsonParam").val();
    var photoArray = [];
    //alert(propJson);
    var divDropZone = $("#divDropZone").dropzone({
        url: "/api/Upload/UploadPhoto",
        paramName: "file",
        params: { propertiesJson: propJson },
        maxFilesize: 10,
        addRemoveLinks: true,
        uploadMultiple: true,
        error: function (file, response) {
            file.previewElement.classList.add("dz-error");
        },
        success: function (file, response) {
            file.previewElement.classList.add("dz-success");
            photoArray = photoArray.concat(response);
            photoArray = photoArray.filter(function (item, pos) { return photoArray.indexOf(item) == pos });
            $("#hdnPhotoNamesArray").val(JSON.stringify(photoArray));
            console.log($("#hdnPhotoNamesArray").val());
        },
        init: function () {
            addRemoveLinks: true,
                this.on("complete", function (data) {
                    var res = JSON.parse(data.xhr.responseText);
                });
        },
        removedfile: function (file) {
            photoArray = photoArray.filter(function (obj) {
                return obj.Name !== file.name;
            });
            $(document).find(file.previewElement).remove();
            $("#hdnPhotoNamesArray").val(JSON.stringify(photoArray));
            console.log($("#hdnPhotoNamesArray").val());
        }
    });
});

var deletedPhotoArray = [];
function DeletePropertyPhoto(imageId) {
    deletedPhotoArray.push(imageId);
    $("#hdnJsonDeletedPhotos").val(JSON.stringify(deletedPhotoArray));
    console.log($("#hdnJsonDeletedPhotos").val());
    $('#' + imageId).remove();
}
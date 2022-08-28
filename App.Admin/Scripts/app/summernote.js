function setupSummernote(summerNoteElement) {
    summerNoteElement.summernote(
    {
        height: 300, //set editable area's height http://hackerwins.github.io/summernote/features.html
        codemirror: {
            // codemirror options
            theme: 'monokai'
        },
        toolbar: [
            //[groupname, [button list]]
            ['style', ['bold', 'italic', 'underline', 'clear', 'strikethrough']],
            ['fontname', ['fontname']],
            ['color', ['color']],
            ['para', ['ul', 'ol', 'paragraph']],
            ['table', ['table']],
            ['insert', ['picture', 'link', 'video']],
            ['misc', ['fullscreen', 'codeview', 'undo', 'redo']]

        ],
        onImageUpload: function (files, editor, welEditable) {
            for (var i = 0, l = files.length; i < l; i++) {
                uploadPhoto(files[i], editor, welEditable, summerNoteElement);
            }
        },
        onChange: function (contents, $editable) {
            summerNoteElement.val(summerNoteElement.code());
        }
    });
}

function uploadPhoto(file, editor, welEditable, summerNoteElement) {
    var data = new FormData();
    data.append("SummernotePhoto", file);
    var url = "/api/Upload/UploadSummernotePhoto";
    $.ajax({
        data: data,
        type: "POST",
        url: url,
        cache: false,
        contentType: false,
        processData: false,
        success: function (photo) {
            editor.insertImage(welEditable, photo);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}
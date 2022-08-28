
//Validate URL names using PageName attribute
function validatePageName(txtfield) {
    var illegals = ['&', '%', '$', '^', '=', '+', '/', '\\', ',', '#', '@', '!', '~', '*', '.', '[', ']', '<', '>', '?', ';', ':', '"', '}', '{', "|"];
    var pageName = jQuery.trim(txtfield.val().toLowerCase());
    pageName = pageName.replace(/\s+/g, "-").replace(/-+/, "-");

    for (i = 0; i < illegals.length; i++) {
        pageName = pageName.replace(illegals[i], "-");
    }

    pageName = pageName.replace('.','-').replace('--', '-').replace('--', '-').replace('--', '-').replace('--', '-');
    txtfield.val(pageName);
}

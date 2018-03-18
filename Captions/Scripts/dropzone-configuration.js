$(document).ready(function () {
    Dropzone.autoDiscover = false;
    $('#myDropzone').dropzone({
        paramName: "files",
        clickable: '#previews',
        previewsContainer: "#previewFiles",
        autoProcessQueue: false,
        uploadMultiple: true,
        parallelUploads: 100,
        maxFiles: 100,
        maxFilesize: 100, //max file size in MB,
        addRemoveLinks: true,
        dictResponseError: 'Server not Configured',
        acceptedFiles: ".png,.jpg,.gif,.bmp,.jpeg",// use this to restrict file type
        init: function () {
            var self = this;
            // config
            self.options.addRemoveLinks = true;
            self.options.dictRemoveFile = "Delete";

            //New file added
            self.on("addedfile", function (file) {
                console.log('new file added ', file);
                $('.dz-success-mark').hide();
                $('.dz-error-mark').hide();
            });
            // Send file starts
            self.on("sending", function (file) {
                $('.meter').show();
            });

            // File upload Progress
            self.on("totaluploadprogress", function (progress) {
                $('.roller').width(progress + '%');
            });

            self.on("queuecomplete", function (progress) {
                $('.meter').delay(999).slideUp(999);
            });

            $('#Submit').on("click", function (e) {
                e.preventDefault();
                e.stopPropagation();
                // Validate form here if needed

                if (self.getQueuedFiles().length > 0) {
                    self.processQueue();


                } else {
                    self.uploadFiles([]);
                    $('#myDropzone').submit();
                }

            });

            self.on("successmultiple", function (files, response) {
                // Gets triggered when the files have successfully been sent.
                // Redirect user or notify of success.
                // response should be the HTML of the page to render
                //
                swal("Files Uploaded", "Upload Complete", "success").then(function (result) {
                    if (result) {
                        location.reload(true);
                    }
                });
            });
        }
    });
});
// Write your JavaScript code.
$(document).ready(function (eve) {
    $("#btnsample").on('click', function (eve) {
        var $selectedTypeId = parseInt($('#UploadTypeId').prop('selectedIndex'));
        if ($selectedTypeId === 0) {
            $('#sampleDownloadStatus').show();
            return 0;
        } else {
            $('#sampleDownloadStatus').hide();
        }
        window.location = '/Home/DownloadSampleTemplate/?templateId=' + $selectedTypeId; 
    });
});

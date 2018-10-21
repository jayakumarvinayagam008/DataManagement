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

    $("#btnNumberLookUp").on('click', function (eve) {
        var fileName = $('#hndLookupId').val();
        window.location = '/Home/DownLoadNumberLookup/?fileName=' + fileName;
    });

    $("#btnCustomerDataSearch").on('click', function (eve) {
        var selectedCities = $('#cityId').val();
        var networks = $('#networkId').val();
        var dataQualities = $('#dataQualityId').val();
        var businessVerticalIds = $('#businessVerticalId').val();
        var tags = $('#tags').val();
        if (selectedCities !== null
            || networks !== null
            || dataQualities !== null
            || businessVerticalIds !== null
            || (tags !== null && tags !== '')
        ) {
            var customerDataSearch = {
                'Cities': selectedCities,
                'DataQuantities': dataQualities,
                'Tags': tags,
                'Network': networks,
                'BusinessVertical': businessVerticalIds
            };

            $.ajax({
                url: '/Home/CustomerData/',
                type: 'post',
                dataType: 'json',
                data: { customerDataSearch: customerDataSearch },
                success: function (data) {
                    UpdateDashBoard(data);
                }
            });
        } else {
            alert('selectedCities');
        }
    });
    $("#btnCustomerExcelExport").on('click', function (eve) {
        var $fileName = $('#downloadLink').val();
        if ($fileName !== '') {
            window.location = '/Home/Export/?fileName=' + $fileName +'&type=xlsx';
           
        } else {
           alert('file does not exist')
        }
        
    });

});
//{"Cities":["Bangalore"],"DataQuantities":null,"Tags":"","Network":null,"BusinessVertical":null}
function UpdateDashBoard(customerData) {
    $('#dashBoardItem').empty();
    $('#spnTotal').text(customerData.total);
    $('#downloadLink').val(customerData.downloadLink);
    var listItems = '';
    for (var key in customerData) {
        if (customerData.hasOwnProperty(key)) {

            if (dashBoardItem[key] !== null
                && dashBoardItem[key] !== undefined
                && dashBoardItem[key] !== 'undefined') {
                $('#dashBoardItem').append(ConstructDashboardItem(dashBoardItem[key], customerData[key]));
            }
        }
    }
    $('#dashboardBlock').show();
    
}
var dashBoardItem = {
    'city': 'City',
    'operator': 'Operator',
    'clientBusinessVertical': 'Client Business Vertical',
    'dbquality': 'DB Quality',
    'clientName': 'Client Name',
    'dateOfUse': 'Date Of Use',
    'numbers': 'Numbers'
};
function ConstructDashboardItem(name, value) {
    return '<li  class="list-group-item d-flex justify-content-between align-items-center"><span class="caption">' + name + '</span><span class="badge badge-primary badge-pill">' + value.toFixed(2) + '%</span></li >';
}
/*
 * city
operator
clientBusinessVertical
dbquality
clientName
dateOfUse
numbers

 {
   "total":517,
   "city":74.08123791102514,
   "operator":74.08123791102514,
   "clientBusinessVertical":74.08123791102514,
   "dbquality":74.08123791102514,
   "clientName":74.08123791102514,
   "dateOfUse":74.08123791102514,
   "numbers":74.08123791102514
}
 */
function ShowApplicationDetals(application) {
    const BASEPATHURL = window.location.origin;
    debugger
    $.ajax({
        //url: '@Url.Action("ShowApplicationDetails", "Student")',
        url: BASEPATHURL+'/Student/ShowApplicationDetails',
        type: 'POST',
        // data: { applicationId: applicationId, status: status,remarks: remarks }, To-do add remarks column in PassApplication table;
        data: { applicationId: applicationId, status: status },
        success: function (response) {
            if (response.success) {
                alert('Status updated successfully');
            } else {
                alert('Error: ' + response.message);
            }
        },
        error: function () {
            alert('An error occurred while updating the status');
        }
    });
}

function UpdateStatus(application) {
    const BASEPATHURL = window.location.origin;
    debugger
    $.ajax({
        //url: '@Url.Action("ShowApplicationDetails", "Student")',
        url: BASEPATHURL + '/Admin/UpdateStatus',
        type: 'POST',
        // data: { applicationId: applicationId, status: status,remarks: remarks }, To-do add remarks column in PassApplication table;
        data: { applicationId: application.applicationId, status: application.status },
        success: function (response) {
            if (response.success) {
                alert('Status updated successfully');
            } else {
                alert('Error: ' + response.message);
            }
        },
        error: function () {
            alert('An error occurred while updating the status');
        }
    });
}
// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function GetFieldValue(name) {
    let field = '#' + name;
    return $(field).val() ?? '';
}
function GetJsToSystemDate() {

}

/// Returns 0 if same;
/// Return 1 if firstDate is greater than second
/// Return -1 if firstDate is greater than second
function CompareDate(firstDate, secondDate) {
    if (typeof (firstDate) == 'string') {
        firstDate = new Date(firstDate);
    }
    firstDate = firstDate.setHours(0, 0, 0, 0);
    firstDate = new Date(firstDate);

    if (typeof (secondDate) == 'string') {
        secondDate = new Date(secondDate);
    }
    secondDate = secondDate.setHours(0, 0, 0, 0);
    secondDate = new Date(secondDate);
    if (firstDate.getTime() == secondDate.getTime()) {
        return 0;
    }
    if (firstDate.getTime() > secondDate.getTime()) {
        return 1;
    }   
    return -1;

}

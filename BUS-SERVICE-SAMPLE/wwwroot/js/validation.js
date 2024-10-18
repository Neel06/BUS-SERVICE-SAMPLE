$(document).ready(function () {
    $('#registerForm').submit(function (e) {
        debugger;
        var password = $('#Password').val();
        var confirmPassword = $('#ConfirmPassword').val();
        ValidateRegistrationFields(e);
    });

    $('#loginForm').submit(function (e) {
        debugger;
        // You can add more validation here
        var Email = $('#Email').val();
        var password = $('#Password').val();
        if (!Email) {
            alert("Enter Email!!");
            e.preventDefault();
        }
        if (!password) {
            alert("Enter Password!!");
            e.preventDefault();
        }

    });

    function ValidateRegistrationFields(e) {
        let studentID = GetFieldValue('StudentID');
        if (!studentID) {
            alert("Please enter Student Id!!");
            e.preventDefault();
        }
        let Email = GetFieldValue('Email');
        if (!Email) {
            alert("Please enter Email!!");
            e.preventDefault();
        }
        let Password = GetFieldValue('Password');
        if (!Password) {
            alert("Please enter Password!!");
            e.preventDefault();
        }
        let ConfirmPassword = GetFieldValue('ConfirmPassword');
        if (!ConfirmPassword) {
            alert("Please enter Confirm Password!!");
            e.preventDefault();
        }
        let Name = GetFieldValue('Name');
        if (!Name) {
            alert("Please enter Name!!");
            e.preventDefault();
        }
        let BirthDate = GetFieldValue('BirthDate');
        if (!BirthDate.trim()) {
            alert("Please enter your birthdate!!");
            e.preventDefault();
        }
        if (CompareDate(BirthDate, new Date()) == '1') {
            alert("Enter valid Birthdate!!");
            e.preventDefault();
        }
        if (Password !== ConfirmPassword) {
            alert("Passwords do not match.");
            e.preventDefault();
        }
    }
});

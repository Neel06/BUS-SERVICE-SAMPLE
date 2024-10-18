// passApplication.js

// Wait for the DOM to fully load
document.addEventListener('DOMContentLoaded', function () {

    // Add event listener to the "Same as Permanent Address" checkbox
    const sameAsPermanantCheckbox = document.getElementById('SameAsPermanant');
    const addressPermanantFields = ['DistrictPermanant', 'BlockPermanant', 'ClusterPermanant', 'VillagePermanant', 'AddressPermanant'];
    const addressCurrentFields = ['DistrictCurrent', 'BlockCurrent', 'ClusterCurrent', 'VillageCurrent', 'AddressCurrent'];

    sameAsPermanantCheckbox.addEventListener('change', function () {
        if (this.checked) {
            // Copy permanent address fields to current address fields
            addressPermanantFields.forEach((field, index) => {
                document.getElementById(addressCurrentFields[index]).value = document.getElementById(field).value;
            });
            // Disable current address fields
            addressCurrentFields.forEach(field => {
                document.getElementById(field).readOnly = true;
            });
        } else {
            // Enable current address fields
            addressCurrentFields.forEach(field => {
                document.getElementById(field).readOnly = false;
                document.getElementById(field).value = ''; // Clear the current address fields
            });
        }
    });

    // Custom validation for form submission
    const applyPassForm = document.getElementById('applyPassForm');

    applyPassForm.addEventListener('submit', function (event) {
        event.preventDefault();
        event.stopPropagation();

        if (!ValidateForm()) {
            // If validation fails, prevent submission and show invalid feedback
            applyPassForm.classList.add('was-validated');
        } else {
            // Submit the form if all validations pass
            applyPassForm.submit();
        }
    });
});

function ApplyPass() {
    const applyPassForm = document.getElementById('applyPassForm');

    if (!ValidateForm()) {
        applyPassForm.classList.add('was-validated');
    } else {
        // Submit the form if all validations pass
        document.forms.applyPassForm.action = '/Student/ApplyPass';
        applyPassForm.submit();
    }
}

// Custom form validation for each field
function ValidateForm() {
    let isValid = true;

    // Validate Name (required)
    if (isFieldEmpty('Name')) {
        markInvalid('Name', 'Please enter your name.');
        isValid = false;
    } else {
        markValid('Name');
    }

    // Validate Gender (Gender - must be Male or Female)
    const gender = document.getElementById('Gender').value;
    if (gender !== 'Male' && gender !== 'Female') {
        markInvalid('Gender', 'Please select a valid gender.');
        isValid = false;
    } else {
        markValid('Gender');
    }

    // Validate DistrictPermanant (required)
    if (isFieldEmpty('DistrictPermanant')) {
        markInvalid('DistrictPermanant', 'Please enter your permanent district.');
        isValid = false;
    } else {
        markValid('DistrictPermanant');
    }

    // Continue validation for other fields like BlockPermanant, AddressPermanant, etc.
    // Validate MobileNumber (10 digits)
    const mobileField = document.getElementById('MobileNumber');
    const mobileNumberPattern = /^[0-9]{10}$/;
    if (!mobileNumberPattern.test(mobileField.value)) {
        markInvalid('MobileNumber', 'Please enter a valid 10-digit mobile number.');
        isValid = false;
    } else {
        markValid('MobileNumber');
    }

    // Validate Email (must be in valid email format)
    const emailField = document.getElementById('Email');
    const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailPattern.test(emailField.value)) {
        markInvalid('Email', 'Please enter a valid email address.');
        isValid = false;
    } else {
        markValid('Email');
    }

    // Validate DateOfBirth (must be a valid date and not in the future)
    const dobField = document.getElementById('DateOfBirth');
    if (!isValidDate(dobField.value) || new Date(dobField.value) > new Date()) {
        markInvalid('DateOfBirth', 'Please enter a valid date of birth.');
        isValid = false;
    } else {
        markValid('DateOfBirth');
    }

    // Validate PassFrom and PassTo (PassTo should be greater than PassFrom)
    const passFromField = document.getElementById('PassFrom');
    const passToField = document.getElementById('PassTo');
    if (new Date(passFromField.value) >= new Date(passToField.value)) {
        markInvalid('PassTo', 'Pass To date must be later than Pass From date.');
        isValid = false;
    } else {
        markValid('PassTo');
    }

    // Validate numeric fields like DepositAmount, PassAmount, etc.
    const depositAmountField = document.getElementById('DepositAmount');
    if (depositAmountField.value <= 0) {
        markInvalid('DepositAmount', 'Please enter a valid deposit amount.');
        isValid = false;
    } else {
        markValid('DepositAmount');
    }

    // Continue similar validations for all other fields based on data type
    // ...

    return isValid;
}

// Helper function to check if a field is empty
function isFieldEmpty(fieldId) {
    const field = document.getElementById(fieldId);
    return !field.value.trim();
}

// Helper function to validate date format (yyyy-mm-dd)
function isValidDate(dateString) {
    const regEx = /^\d{4}-\d{2}-\d{2}$/;
    if (!dateString.match(regEx)) return false;  // Invalid format
    const date = new Date(dateString);
    const timestamp = date.getTime();
    if (typeof timestamp !== 'number' || Number.isNaN(timestamp)) return false; // NaN value, Invalid date
    return date.toISOString().startsWith(dateString);
}

// Mark field as invalid with custom message
function markInvalid(fieldId, message) {
    debugger;
    const field = document.getElementById(fieldId);
    field.classList.add('is-invalid');
    const feedback = field.nextElementSibling;
    if (feedback && feedback.classList.contains('invalid-feedback')) {
        feedback.textContent = message;
    }
}

// Mark field as valid (removes invalid state)
function markValid(fieldId) {
    const field = document.getElementById(fieldId);
    field.classList.remove('is-invalid');
    field.classList.add('is-valid');
}



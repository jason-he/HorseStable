function previewFile() {
    var preview = document.querySelector("#MainContent_ImageHorsePicture");
    var file = document.querySelector('#MainContent_FileUploadHorsePicture').files[0];
    var reader = new FileReader();

    reader.onloadend = function () {
        preview.src = reader.result;
    }

    if (file) {
        reader.readAsDataURL(file);
    } else {
        preview.src = "";
    }
}

function validateData(minValue, maxValue, curObj, DisplayName, decPos) {
    var arg = curObj.value;

    if (arg.length == 0)
        return 1;

    for (var i = 0; i < arg.length; i++) {
        var testChar = arg.charAt(i);
        if ((testChar < "0" || testChar > "9") && testChar != "." && testChar != ",") {
            // - is valid if first character
            if ((testChar == "-") && i == 0)
                continue;
            curObj.style.backgroundColor = "Red";
            alert("You have entered a non-numeric value for " + displayName + ", please change this entry.");
            curObj.focus();
            return 0;
        }
        else if (testChar == "." && (decPos < arg.length - i - 1)) {
            curObj.style.backgroundColor = "Red";
            alert("You should enter only " + decPos + " digits after the decimal.");
            curObj.focus();
            return 0;
        }
    }

    if (curObj.value > maxValue || minValue > curObj.value) {
        curObj.style.backgroundColor = "Red";
        alert("Please enter a valid value within [" + minValue + "," + maxValue + "]");
        curObj.focus();
        return 0;
    }

    curObj.style.backgroundColor = "white";
    return 1;
}

function SetEventHanlders() {
    var ControlElement1 = document.getElementById('MainContent_FileUploadHorsePicture');
    if (ControlElement1) {
        ControlElement1.onchange = function () {
            previewFile();
        }
    }

    var ControlElement2 = document.getElementById('MainContent_TextBoxHorseWeight');
    if (ControlElement2) {
        ControlElement2.onchange = function () {
            validateData(100, 500, ControlElement2, "Weight", 2);
        }
    }

    var ControlElement3 = document.getElementById('MainContent_TextBoxHorseSize');
    if (ControlElement3) {
        ControlElement3.onchange = function () {
            validateData(1, 2, ControlElement3, "Height", 2);
        }
    }

    var ControlElement4 = document.getElementById('MainContent_TextBoxHorseRidingSchool');
    if (ControlElement4) {
        ControlElement4.onchange = function () {
            validateData(0, 100, ControlElement4, "Riding School Proficiency", 2);
        }
    }

    var ControlElement5 = document.getElementById('MainContent_TextBoxHorseShowJumping');
    if (ControlElement5) {
        ControlElement5.onchange = function () {
            validateData(0, 100, ControlElement5, "Show Jumping Proficiency", 2);
        }
    }

    var ControlElement6 = document.getElementById('MainContent_TextBoxHorseDressage');
    if (ControlElement6) {
        ControlElement6.onchange = function () {
            validateData(0, 100, ControlElement6, "Dressage Proficiency", 2);
        }
    }

    var ControlElement7 = document.getElementById('MainContent_TextBoxHorseRacing');
    if (ControlElement7) {
        ControlElement7.onchange = function () {
            validateData(0, 100, ControlElement7, "Racing Proficiency", 2);
        }
    }
}
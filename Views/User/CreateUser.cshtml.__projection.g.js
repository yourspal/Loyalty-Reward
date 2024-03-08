/* BEGIN EXTERNAL SOURCE */

/* END EXTERNAL SOURCE */
/* BEGIN EXTERNAL SOURCE */

    $(document).ready(function () {
        $("#submitbutton").click(function () {
            return validatePassword();
        });
    });

    function validatePassword() {
        if ($("#Password").val() === $("#ConfirmPassword").val()) {
            return true;
        }
        else {
            alert("password not same");
            return false
        }
    };

/* END EXTERNAL SOURCE */

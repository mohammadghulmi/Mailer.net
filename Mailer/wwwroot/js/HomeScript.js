function CheckEmail(email) {
    if (email.length <= 2) {
        return false;
    }
    //If whether email has @ character.
    if (email.indexOf("@") == -1) {
        return false;
    }

    var parts = email.split("@");
    var dot = parts[1].indexOf(".");
    var len = parts[1].length;
    var dotSplits = parts[1].split(".");
    var dotCount = dotSplits.length - 1;


    //Check whether Dot is present, and that too minimum 1 character after @.
    if (dot == -1 || dot < 2 || dotCount > 2) {
        return false;
    }

    //Check whether Dot is not the last character and dots are not repeated.
    for (var i = 0; i < dotSplits.length; i++) {
        if (dotSplits[i].length == 0) {
            return false;
        }
    }

    return true;
    
}
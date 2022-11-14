function SuccessfulRequest(result) {
    $("#ajax-results").text(result.text);
};

function FailedRequest(result) {
    $("#ajax-results").text(result.text);
};
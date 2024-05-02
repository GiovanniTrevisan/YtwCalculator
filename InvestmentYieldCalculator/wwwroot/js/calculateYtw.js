document.addEventListener('DOMContentLoaded', function () {
    document.getElementById('calculateYtwButton').addEventListener('click', function (event) {
        event.preventDefault();

        var formData = new FormData(document.getElementById('calculateYtwForm'));
        var xhr = new XMLHttpRequest();
        xhr.open('POST', '/InvestmentYieldCalculator/CalculateYtw', true);
        xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
        xhr.onload = function () {
            if (xhr.status === 200) {
                console.log(xhr.responseText);
            }
        };
        xhr.send(new URLSearchParams(formData).toString());
    });
});

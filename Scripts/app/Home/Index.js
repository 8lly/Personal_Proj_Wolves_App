var myApp = angular.module('myFootballWebsiteApp', []);

myApp.controller('IndexController', function
    IndexController($scope, $interval, $filter) {

    $scope.headlineNews = getHeadlineNews();

    function getHeadlineNews() {
        fetch('https://localhost:44302/Api/Home/GetHeadlineNews')
            .then(response => {
                if (response.ok) {
                    response.json().then(json => {
                        $scope.headlineNews = json;
                        return;
                    })
                }
                else {
                    throw new Error('News has not been found.');
                    return;
                }
            })
    };



    $scope.getArticle = function (articleId) {
        $scope.activeArticle = $scope.headlineNews[articleId];
    };

    $scope.currentTime = new Date().toLocaleTimeString();

    $interval(function () {

        var currentTime = new Date();
        var currentTimeHrs = currentTime.getHours();

        if (currentTimeHrs <= 11) {
            $scope.greeting = "Good Morning";
        }
        else if (currentTimeHrs <= 16) {
            $scope.greeting = "Good Afternoon";
        }
        else if (currentTimeHrs >= 17) {
            $scope.greeting = "Good Evening";
        }

        $scope.currentTime = currentTime.toLocaleTimeString();

    }, 1000);

});
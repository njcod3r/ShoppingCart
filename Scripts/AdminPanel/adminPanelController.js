/// <reference path="../angular.js" />
angular.module('adminPanelApp', ['angularFileUpload'])
    .filter('true_false', function () {
        return function (text) {
            if (text) {
                return 'Yes';
            }
            return 'No';
        }
    })
//.config(function ($routeProvider, $locationProvider) {
//    $routeProvider
//    .when('/adminPanel/Login', {
//        controller: 'loginCtrl'
//    })

//    .when('/adminPanel/admin', {
//        controller: 'loginCtrl',
//        templateUrl: '~/Scripts/AdminPanel/shops.html'
//    })
//    //.otherwise({redirectTo:"/adminPanel/admin"});

//    $locationProvider.html5Mode({
//        enabled: true,
//        requireBase: false
//    });
//})
.factory('adminPanelSrv', function ($http, $q) {
    return {
        //adminPanelLogin: function (username, password) { return $http.get('/api/AdminPanelapi/UserAuthentication?UserName=' + username + "&password=" + password); },
        adminPanelLoginController: function (userAuth) {  return $http.post('/AdminPanel/UserAuthentication', userAuth); },

        adminPanelShopById: function (shopId) { return $http.get('/api/AdminPanelapi/getAllShopById?shopId=' + shopId); },
        adminPanelShopList: function () { return $http.get('/api/AdminPanelapi/getAllShopList'); },
        adminPanelShopCreate: function (shop) { return $http.post('/api/AdminPanelapi/createShop', shop); },
        adminPanelShopUpdate: function (shop) { return $http.post('/api/AdminPanelapi/updateShop', shop); },
        adminPanelShopDelete: function (shop) { return $http.post('/api/AdminPanelapi/deleteShop', shop); },

        adminPanelGetCategories: function () { return $http.get('/api/AdminPanelapi/getCategories'); },
        adminPanelCategoryById: function (categoryId) { return $http.get('/api/AdminPanelapi/getAllCategoryById?categoryId=' + categoryId); },
        adminPanelCategoryList: function () { return $http.get('/api/AdminPanelapi/getAllCategoriesList'); },
        adminPanelCategoryCreate: function (category) { return $http.post('/api/AdminPanelapi/createCategory', category); },
        adminPanelCategoryUpdate: function (category) { return $http.post('/api/AdminPanelapi/updateCategory', category); },
        adminPanelCategoryDelete: function (category) { return $http.post('/api/AdminPanelapi/deleteCategory', category); },

        adminPanelContactInfo: function () { return $http.get('/api/AdminPanelapi/getContactInfoAndUrl') },
        adminPanelContactInfoUpdate: function (contactInfo) { return $http.post('/api/AdminPanelapi/updateContactInfoAndUrl', contactInfo) }
    }
})
//.controller('loginCtrl', function ($scope, adminPanelSrv) {
//    $scope.loginErrorMsg = true;
//    $scope.user = {};
//    $scope.userAuthentication = function (username, password) {
//        adminPanelSrv.adminPanelLogin(username, password).success(function (data) {
//            console.log(data);
//            $scope.user = data;
//            $scope.loginErrorMsg = true;
//            window.location.href = '/AdminPanel/Admin';
//        }).error(function (data) {
//            $scope.loginErrorMsg = false;
//        });
//    }

//})
.controller('loginCtrl', function ($scope, adminPanelSrv) {
    $scope.loginErrorMsg = true;
    $scope.userInfo = {};
    $scope.userInfo.rememberMe = false;
    $scope.userAuthentication = function (userInfo) {  
        adminPanelSrv.adminPanelLoginController(userInfo).success(function (data) {
            $scope.user = data;
            $scope.loginErrorMsg = true;
            window.location.href = '/AdminPanel/Admin';
        }).error(function (data) {
            $scope.loginErrorMsg = false;
        });
    }

})
.controller('adminPanelShopListCtrl', function ($scope, $upload, adminPanelSrv) {
    $scope.categories = {};
    adminPanelSrv.adminPanelGetCategories().success(function (data) {
        $scope.categories = data;
    }).error(function () {
    });
    $scope.SelectedFileForUpload = '';
    $scope.SelectedFileForUpload1 = '';
    $scope.SelectedFileForUpload2 = '';
    $scope.SelectedFileForUpload3 = '';

    $scope.shopErrorMsg = true;
    $scope.shop = {};
    //$scope.shop.categoryTitle = '';
    $scope.shop.shopImage = '';
    $scope.shop.shopImage2 = '';
    $scope.shop.shopImage3 = '';
    $scope.shop.shopImage4 = '';

    $scope.isupdate = false;
    $scope.upload = function (file) {
        if (file) {
            $upload.upload({
                url: '/api/AdminPanelapi/UploadFileShop',
                fields: { 'username': $scope.username },
                file: file
            }).success(function (data, status, headers, config) {
                //console.log(config);
                //alert("Thanks for the upload!\r\nFilename: " + config.file[0].name + "\r\nResponse: " + data);
                alert('Photo Saved');

            }).error(function (error) {
                alert("Ooops, something went wrong!");
                //console.log("Error!", error);
            });
        }
    };



    $scope.cancel = function () {
        $scope.shopErrorMsg = true;
        $scope.shop = {};
        $scope.file = '';
        $scope.file1 = '';
        $scope.file2 = '';
        $scope.file3 = '';
    }

    $scope.selectShop = function (shop) {
        adminPanelSrv.adminPanelShopById(shop.ShopId).success(function (data) {
            $scope.shop = data;
            $scope.isupdate = true;
        })

    }

    $scope.selectFileforUpload = function (file) {
        $scope.SelectedFileForUpload = file[0];
    }

    $scope.selectFileforUpload1 = function (file) {
        $scope.SelectedFileForUpload1 = file[0];
    }

    $scope.selectFileforUpload2 = function (file) {
        $scope.SelectedFileForUpload2 = file[0];
    }

    $scope.selectFileforUpload3 = function (file) {
        $scope.SelectedFileForUpload3 = file[0];
    }


    $scope.createShop = function (shop) {

        if ($scope.isupdate == false) {
            shop.shopImage = '/Images/ShopImages/' + $scope.SelectedFileForUpload.name;
            if (shop.shopImage == '/Images/ShopImages/undefined') {
                shop.shopImage = '';
            }

            shop.shopImage1 = '/Images/ShopImages/' + $scope.SelectedFileForUpload1.name;
            if (shop.shopImage1 == '/Images/ShopImages/undefined') {
                shop.shopImage1 = '';
            }

            shop.shopImage2 = '/Images/ShopImages/' + $scope.SelectedFileForUpload2.name;
            if (shop.shopImage2 == '/Images/ShopImages/undefined') {
                shop.shopImage2 = '';
            }

            shop.shopImage3 = '/Images/ShopImages/' + $scope.SelectedFileForUpload3.name;
            if (shop.shopImage3 == '/Images/ShopImages/undefined') {
                shop.shopImage3 = '';
            }
            adminPanelSrv.adminPanelShopCreate(shop).success(function () {
                $('#modal').modal('hide').on('hidden.bs.modal', function () {
                    $scope.shop = {};
                    $scope.file = '';
                    $scope.file1 = '';
                    $scope.file2 = '';
                    $scope.file3 = '';
                })
                adminPanelSrv.adminPanelShopList().success(function (data) {
                    $scope.shopList = data;
                });
            }).error(function () {
                $scope.shopErrorMsg = false;
                $scope.file = '';
                $scope.file1 = '';
                $scope.file2 = '';
                $scope.file3 = '';
            });
        }
        else {
            if ($scope.SelectedFileForUpload.name != undefined) {
                shop.shopImage = '/Images/ShopImages/' + $scope.SelectedFileForUpload.name;
            }
            if ($scope.SelectedFileForUpload1.name != undefined) {
                shop.shopImage1 = '/Images/ShopImages/' + $scope.SelectedFileForUpload1.name;
            }
            if ($scope.SelectedFileForUpload2.name != undefined) {
                shop.shopImage2 = '/Images/ShopImages/' + $scope.SelectedFileForUpload2.name;
            }
            if ($scope.SelectedFileForUpload3.name != undefined) {
                shop.shopImage3 = '/Images/ShopImages/' + $scope.SelectedFileForUpload3.name;
            }


            adminPanelSrv.adminPanelShopUpdate(shop).success(function () {
                $('#modal').modal('hide').on('hidden.bs.modal', function () {
                    $scope.shop = {};
                    $scope.file = '';
                    $scope.file1 = '';
                    $scope.file2 = '';
                    $scope.file3 = '';
                })
                adminPanelSrv.adminPanelShopList().success(function (data) {
                    $scope.shopList = data;
                });
            }).error(function () {
                $scope.shopErrorMsg = false;
                $scope.file = '';
                $scope.file1 = '';
                $scope.file2 = '';
                $scope.file3 = '';
            });
        }

    }

    $scope.deleteShop = function (shop) {
        adminPanelSrv.adminPanelShopDelete(shop).success(function (data) {
            adminPanelSrv.adminPanelShopList().success(function (data) {
                $scope.shopList = data;
            }).error(function () {
            });
        }).error(function () {
        });
    }


    adminPanelSrv.adminPanelShopList().success(function (data) {
        $scope.shopList = data;
    }).error(function () { });
})
.controller('adminPanelCategoryListCtrl', function ($scope, $upload, adminPanelSrv) {

    $scope.SelectedFileForUpload = '';
    $scope.categoryErrorMsg = true;
    $scope.category = {};
    $scope.category.categoryTitle = '';
    $scope.category.categoryImage = '';
    $scope.isupdate = false;
    $scope.upload = function (file) {
        if (file) {            
            $upload.upload({
                url: '/api/AdminPanelapi/UploadFile',
                fields: { 'username': $scope.username },
                file: file
            }).success(function (data, status, headers, config) {
                //console.log(config);
                //alert("Thanks for the upload!\r\nFilename: " + config.file[0].name + "\r\nResponse: " + data);
                alert('Photo Saved');

            }).error(function (error) {
                alert("Ooops, something went wrong!");
                //console.log("Error!", error);
            });
        }
    };


    $scope.cancel = function () {
        $scope.categoryErrorMsg = true;
        $scope.category = {};
        $scope.file = '';
    }

    $scope.selectCategory = function (category) {
        adminPanelSrv.adminPanelCategoryById(category.CategoryId).success(function (data) {
            $scope.category = data;
            file = data.CategoryImage;
            $scope.isupdate = true;
        })

    }

    $scope.selectFileforUpload = function (file) {
        $scope.SelectedFileForUpload = file[0];
    }

    $scope.createCategory = function (category) {


        if ($scope.isupdate == false) {
            category.categoryImage = '/Images/CategoryImages/' + $scope.SelectedFileForUpload.name;
            if (category.categoryImage == '/Images/CategoryImages/undefined') {
                category.categoryImage = '';
            }
            adminPanelSrv.adminPanelCategoryCreate(category).success(function () {
                $('#modal').modal('hide').on('hidden.bs.modal', function () {
                    $scope.category = {};
                    $scope.file = '';
                })
                adminPanelSrv.adminPanelCategoryList().success(function (data) {
                    $scope.categoryList = data;
                });
            }).error(function () {
                $scope.categoryErrorMsg = false;
                $scope.file = '';
            });
        }
        else {
            if ($scope.SelectedFileForUpload.name != undefined) {
                category.categoryImage = '/Images/CategoryImages/' + $scope.SelectedFileForUpload.name;
            }


            adminPanelSrv.adminPanelCategoryUpdate(category).success(function () {
                $('#modal').modal('hide').on('hidden.bs.modal', function () {
                    $scope.category = {};
                    $scope.file = '';
                })
                adminPanelSrv.adminPanelCategoryList().success(function (data) {
                    $scope.categoryList = data;
                });
            }).error(function () {
                $scope.categoryErrorMsg = false;
                $scope.file = '';
            });
        }

    }

    $scope.deleteCategory = function (category) {
        adminPanelSrv.adminPanelCategoryDelete(category).success(function (data) {
            adminPanelSrv.adminPanelCategoryList().success(function (data) {
                $scope.categoryList = data;
            }).error(function () {
            });
        }).error(function () {
        });


    }

    adminPanelSrv.adminPanelCategoryList().success(function (data) {
        $scope.categoryList = data;
    }).error(function () {
    });

})
.controller('adminPanelContactInfo', function ($scope, adminPanelSrv) {
    $scope.contactErrorMsg = true;
    $scope.contactSuccessMsg = true;
    $scope.updateContact = function (contactInfo) {
        adminPanelSrv.adminPanelContactInfoUpdate(contactInfo).success(function () { $scope.contactErrorMsg = true; $scope.contactSuccessMsg = false; })
        .error(function () { $scope.contactErrorMsg = false; $scope.contactSuccessMsg = true; });
    }
    adminPanelSrv.adminPanelContactInfo().success(function (data) {
        $scope.contactInfo = data;
    }).error(function () {
    });

});

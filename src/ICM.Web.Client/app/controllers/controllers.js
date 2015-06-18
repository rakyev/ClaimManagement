/*#######################################################################
  
  Dan Wahlin
  http://twitter.com/DanWahlin
  http://weblogs.asp.net/dwahlin
  http://pluralsight.com/training/Authors/Details/dan-wahlin

  Normally like the break AngularJS controllers into separate files.
  Kept them together here since they're small and it's easier to look through them.
  example. 

  #######################################################################*/


//This controller retrieves data from the customersService and associates it with the $scope
//The $scope is ultimately bound to the customers view


function clientController($scope, $http) {

    $scope.loading = true;

    $scope.addMode = false;



    //Used to display the data

    $http.get('/api/Client/').success(function (data) {

        $scope.friends = data;

        $scope.loading = false;

    })

    .error(function () {

        $scope.error = "An Error has occured while loading posts!";

        $scope.loading = false;

    });



    $scope.toggleEdit = function () {

        this.client.editMode = !this.client.editMode;

    };

    $scope.toggleAdd = function () {

        $scope.addMode = !$scope.addMode;

    };



    //Used to save a record after edit

    $scope.save = function () {

        alert("Edit");

        $scope.loading = true;

        var client1 = this.client;

        alert(emp);

        $http.put('/api/Client/', client1).success(function (data) {

            alert("Saved Successfully!!");

            emp.editMode = false;

            $scope.loading = false;

        }).error(function (data) {

            $scope.error = "An Error has occured while Saving Client! " + data;

            $scope.loading = false;



        });

    };



    //Used to add a new record

    $scope.add = function () {

        $scope.loading = true;

        $http.post('/api/Client/', this.newclient).success(function (data) {

            alert("Added Successfully!!");

            $scope.addMode = false;

            $scope.clients.push(data);

            $scope.loading = false;

        }).error(function (data) {

            $scope.error = "An Error has occured while Adding Client! " + data;

            $scope.loading = false;



        });

    };



    //Used to edit a record

    $scope.deleteclient = function () {

        $scope.loading = true;

        var clientid = this.client.clientid;

        $http.delete('/api/Client/' + clientid).success(function (data) {

            alert("Deleted Successfully!!");

            $.each($scope.clients, function (i) {

                if ($scope.clients[i].clientid === clientid) {

                    $scope.clients.splice(i, 1);

                    return false;

                }

            });

            $scope.loading = false;

        }).error(function (data) {

            $scope.error = "An Error has occured while Saving Client! " + data;

            $scope.loading = false;



        });

    };

};

app.controller('CustomersController', function ($scope, customersService) {

    //I like to have an init() for controllers that need to perform some initialization. Keeps things in
    //one place...not required though especially in the simple example below
    init();

    function init() {
        $scope.customers = customersService.getCustomers();
    }

    $scope.insertCustomer = function () {
        var firstName = $scope.newCustomer.firstName;
        var lastName = $scope.newCustomer.lastName;
        var city = $scope.newCustomer.city;
        customersService.insertCustomer(firstName, lastName, city);
        $scope.newCustomer.firstName = '';
        $scope.newCustomer.lastName = '';
        $scope.newCustomer.city = '';
    };

    $scope.deleteCustomer = function (id) {
        customersService.deleteCustomer(id);
    };
});

//This controller retrieves data from the customersService and associates it with the $scope
//The $scope is bound to the order view
app.controller('CustomerOrdersController', function ($scope, $routeParams, customersService) {
    $scope.customer = {};
    $scope.ordersTotal = 0.00;

    //I like to have an init() for controllers that need to perform some initialization. Keeps things in
    //one place...not required though especially in the simple example below
    init();

    function init() {
        //Grab customerID off of the route        
        var customerID = ($routeParams.customerID) ? parseInt($routeParams.customerID) : 0;
        if (customerID > 0) {
            $scope.customer = customersService.getCustomer(customerID);
        }
    }

});

//This controller retrieves data from the customersService and associates it with the $scope
//The $scope is bound to the orders view
app.controller('OrdersController', function ($scope, customersService) {
    $scope.customers = [];

    //I like to have an init() for controllers that need to perform some initialization. Keeps things in
    //one place...not required though especially in the simple example below
    init();

    function init() {
        $scope.customers = customersService.getCustomers();
    }
});

app.controller('NavbarController', function ($scope, $location) {
    $scope.getClass = function (path) {
        if ($location.path().substr(0, path.length) == path) {
            return true
        } else {
            return false;
        }
    }
});

//This controller is a child controller that will inherit functionality from a parent
//It's used to track the orderby parameter and ordersTotal for a customer. Put it here rather than duplicating 
//setOrder and orderby across multiple controllers.
app.controller('OrderChildController', function ($scope) {
    $scope.orderby = 'product';
    $scope.reverse = false;
    $scope.ordersTotal = 0.00;

    init();

    function init() {
        //Calculate grand total
        //Handled at this level so we don't duplicate it across parent controllers
        if ($scope.customer && $scope.customer.orders) {
            var total = 0.00;
            for (var i = 0; i < $scope.customer.orders.length; i++) {
                var order = $scope.customer.orders[i];
                total += order.orderTotal;
            }
            $scope.ordersTotal = total;
        }
    }

    $scope.setOrder = function (orderby) {
        if (orderby === $scope.orderby)
        {
            $scope.reverse = !$scope.reverse;
        }
        $scope.orderby = orderby;
    };

});

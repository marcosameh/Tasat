Vue.filter("price", function (value, currency) {
    return (
        currency + value.toString())
    );
});

new Vue({
    el: "#cart",
    data: {
        cartTotalPrice: 0,
        cartItems: [],
        itemToShow: {
            id: 0,
            imageSrc: "",
            price: 0,
            name: "",
            urlName: "",
            description: "",
        },
        itemQuantity: 1,
    },
    mounted: function mounted() {
        var items = JSON.parse(localStorage.getItem("cartItems"));
        if (items) {
            this.cartItems = items;
        }
    },
    methods: {
        addToCart: function (product) {
            var found = false;
            if (this.cartItems) {
                for (var i = 0; i < this.cartItems.length; i++) {
                    if (this.cartItems[i].product.id === product.id) {
                        found = true;
                        this.cartItems[i].quantity++;
                        break;
                    }
                }
            }
            if (!found) {
                this.cartItems.push({ product, quantity: 1 });
                toastr.success(product.name + " is added to cart", "Success");
            }
            localStorage.setItem("cartItems", JSON.stringify(this.cartItems));
        },
        addToCartWithQuantity: function (product, quantity) {
            var found = false;
            if (this.cartItems) {
                for (var i = 0; i < this.cartItems.length; i++) {
                    if (this.cartItems[i].product.id === product.id) {
                        found = true;
                        this.cartItems[i].quantity = quantity;
                        break;
                    }
                }
            }
            if (!found) {
                this.cartItems.push({ product, quantity });
                toastr.success(product.name + " is added to cart", "Success");
            }
            this.itemQuantity = 1;
            localStorage.setItem("cartItems", JSON.stringify(this.cartItems));
        },
        incrementDecrementQuantity: function (event, product) {
            var productToFind = this.cartItems.find(
                (item) => item.product.id == product.id
            );
            if (this.cartItems.length != 0 && productToFind) {
                for (var i = 0; i < this.cartItems.length; i++) {
                    if (this.cartItems[i].product.id === product.id) {
                        this.cartItems[i].quantity = +event.target.value;
                        break;
                    }
                }
            } else {
                this.cartItems.push({ product, quantity: +event.target.value });
                toastr.success(product.name + " is added to cart", "Success");
            }

            localStorage.setItem("cartItems", JSON.stringify(this.cartItems));
        },
        deleteFromCart: function (product) {
            this.cartItems = this.cartItems.filter(
                (cartitem) => cartitem.product.id !== product.id
            );
            localStorage.setItem("cartItems", JSON.stringify(this.cartItems));
        },
        getItemQuantity: function (product) {
            var item = this.cartItems.find(function (item) {
                return product.id == item.product.id;
            });
            if (item) {
                return item.quantity;
            } else {
                return 1;
            }
        },
        showItem: function (product) {
            this.itemToShow = product;
            var shared = { name: product.name, url: "" + product.urlName };
            this.sharer.facebook = shared;
            this.sharer.twitter = shared;
            this.sharer.google = shared;
        }
    },
    computed: {
        totalPrice: function () {
            return this.cartItems.reduce((acc, item) => {
                return (acc += item.product.price * item.quantity);
            }, 0);
        },
        totalQuantity: function () {
            return this.cartItems.reduce((acc, item) => {
                return (acc += item.quantity);
            }, 0);
        },
    },
});

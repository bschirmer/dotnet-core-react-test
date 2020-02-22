import React, { Component } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Button from '@material-ui/core/Button';
import Drawer from '@material-ui/core/Drawer';
import List from '@material-ui/core/List';
import CartItem from './CartItem';
import { Typography } from '@material-ui/core';
import ShoppingCart from '@material-ui/icons/ShoppingCart';
export class Cart extends Component {
    constructor(props) {
        super(props);

        this.state = {
            cartCount: 0,
            cartItems: [],
            isCartDrawOpen: false,
            reloadCart: false,
            checkoutMessage: false
        }

        this.getCartCount = this.getCartCount.bind(this);
        this.openCartDraw = this.openCartDraw.bind(this);
        this.closeCartDraw = this.closeCartDraw.bind(this);
        this.deleteCartItem = this.deleteCartItem.bind(this);
    }

    getCartCount() {
        fetch('https://localhost:5001/cart/count')
            .then(results => {
                return results.json()
            })
            .then(data => {
                console.log("cartcount ",data);
                this.setState({ cartCount: data }, () => console.log(data));
            })
            .catch((e) => console.log(e));
        this.props.resetCartCountUpdate();
    }

    getCartItems() {
        fetch('https://localhost:5001/cart/all')
        .then(results => {
            return results.json();
        })
        .then(data => {
            this.setState({ cartItems: data }, () => console.log(this.state.cartItems));
        })
        .catch((e) => console.log(e));
    }

    componentDidMount() {
        this.getCartCount();
        this.setState({ reloadCart: false});
    }

    componentDidUpdate() {
        if (this.props.updateCartCount) {
            this.getCartCount();
            this.getCartItems();
            if(this.state.cartItems.length === 0 && this.state.isCartDrawOpen){
                this.setState({isCartDrawOpen: false});
            }
        }        
    }   
    
    openCartDraw(){
        this.setState({isCartDrawOpen: true});
        this.getCartItems();
    }
    
    closeCartDraw(){
        this.setState({isCartDrawOpen: false}); 
    }

    deleteCartItem(id){
        fetch('https://localhost:5001/cart/deleteItem', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                Id: Number(id)
            })
        })
        .then(results => { return results.json() })
        .then(data => {
           if(data){
                this.setState({ reloadCart: true });
           }
        })
        .catch((e) => console.log(e));
    }

    render() {
        
        let cartList;
        if(this.state.cartItems.length > 0){
            cartList = this.state.cartItems.map((cartItem) => {
                return <CartItem cartItem={cartItem} deleteCartItem={this.deleteCartItem}/>
            })
        } else {
            cartList = <div className="cart-list cart-message">Your cart is empty</div>
        }

        let checkoutMessage;
        if(this.state.checkoutMessage){
            checkoutMessage = <Typography
                                className="cart-message">
                                This is just a demo store!
                              </Typography>
        }

        return (
            <div id="cart">
                <Button id="cart-button" 
                        variant="contained"
                        startIcon={<ShoppingCart />}
                        onClick={(e) => this.openCartDraw(e)}>
                            Cart ({this.state.cartCount})
                </Button>
                <Drawer anchor="right" 
                        open={this.state.isCartDrawOpen} 
                        onClose={(e) => this.closeCartDraw(e)}>
                    <div className="cart-list">
                        <List>
                            {cartList}
                        </List>
                    </div>
                    
                    <Button size="small" color="primary" onClick={() => { this.setState({checkoutMessage: true}) }} >
                            Go to Checkout
                    </Button>
                    {checkoutMessage}
                </Drawer>
            </div>
        );
    }
}
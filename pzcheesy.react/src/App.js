import React, { Component } from 'react';
import { Header } from './components/Header';
import { NavBar } from './components/NavBar';
import { CheeseOfTheDay } from './components/CheeseOfTheDay';
import { CheeseCards } from './components/CheeseCards';

export default class App extends Component {
    constructor() {
        super();

        this.state = {
            updateCartCount: false
        }

        this.addToCart = this.addToCart.bind(this);
        this.resetCartCountUpdate = this.resetCartCountUpdate.bind(this);
    }

    // I was unsure of how to pass data properly in react
    // My solution is to pass this function as a callback to the cheese cards
    // then update the state and force a re-render to update child components
    addToCart(sku) {
        fetch('https://localhost:5001/cart/add', {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    SKU: sku
                })
            })
            .then(results => { return results.json() })
            .then(data => { console.log(data) })
            .catch((e) => console.log(e));

        this.setState({ updateCartCount: true }, () => console.log("update cart count " + this.state.updateCartCount) );
        
    }

    resetCartCountUpdate() {
        this.setState({ updateCartCount: false });
    }

    render() {
        console.log("render");
        return (
            <div>
                <Header />
                <NavBar updateCartCount={this.state.updateCartCount} resetCartCountUpdate={this.resetCartCountUpdate} />
                <CheeseOfTheDay />
                <CheeseCards addToCart={this.addToCart} />
            </div>
        );
    }
}

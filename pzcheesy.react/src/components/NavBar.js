import React, { Component } from 'react';
import { Cart } from "./Cart";

export class NavBar extends Component {
    constructor(props) {
        super(props);

        this.state = {
            cartCount: 0
        }

        this.getCartCount = this.getCartCount.bind(this);
    }

    getCartCount() {
            fetch('https://localhost:5001/cart/count')
                .then(results => {
                    return results.json()
                })
                .then(data => {
                    console.log(data);
                    this.setState({ cartCount: data }, () => console.log(data));
                })
                .catch((e) => console.log(e));
            this.props.resetCartCountUpdate();
    }

    componentDidMount() {
        this.getCartCount();
    }

    componentDidUpdate() {
        
        if (this.props.updateCartCount) {
            this.getCartCount();
        }   
    }

   

    render() {
        console.log("nave bar render ",this.props.updateCartCount);

        return (
            <div>
                <h3> Nav Bar </h3>
                <h4> Cart ({this.state.cartCount}) </h4>
            </div>
        );
    }
}
import React, { Component } from 'react';
import { Cart } from "./Cart";

export class NavBar extends Component {
    constructor() {
        super();

        this.state = {
            cartCount: 0
        }
    }
    componentDidMount() {
        fetch('/cart/count')
            .then(results => { return results.json() })
            .then(data => {
                this.setState({ cartCount: data });
            });
     }

    render() {
        return (
            <div>
                <h3> Nav Bar </h3>
                <h4> Cart ({this.state.cartCount}) </h4>
            </div>
        );
    }
}
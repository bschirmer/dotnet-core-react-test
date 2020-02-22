import React, { Component } from 'react';
import ListItem from '@material-ui/core/ListItem';
import ListItemText from '@material-ui/core/ListItemText';
import ListItemAvatar from '@material-ui/core/ListItemAvatar';
import Avatar from '@material-ui/core/Avatar';
import Button from '@material-ui/core/Button';
import { Input, InputLabel } from '@material-ui/core';

class CartItem extends Component {
    constructor(props){
        super(props);

        this.state = {
            cartItem: '',
            quantity: '',
            totalcost: ''
        }
    }

    componentDidMount(){
        this.setState({cartItem: this.props.cartItem});

        this.setState({quantity: this.props.cartItem.quantity});

        let totalcost =  this.calculateTotalCost(this.props.cartItem.price, this.props.cartItem.quantity);
        this.setState({totalcost: totalcost});
    }

    handleButtonClick(id, value){
        fetch('https://localhost:5001/cart/updateItem', {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    Id: Number(id),
                    Quantity: Number(value)
                })
            })
            .then(results => { return results.json() })
            .then(data => {
                this.setState({quantity: data.quantity});

                let totalcost = this.calculateTotalCost(this.state.cartItem.price, data.quantity)
                this.setState({totalcost: totalcost});
            })
            .catch((e) => console.log(e));
        
    }

    calculateTotalCost(price, quantity){
        return Math.round(((price * quantity) + Number.EPSILON) * 100) / 100;
    }

    handleInputChange(e){
        this.setState({quantity: e.target.value});
    }

    render(){
        return(
            <div>
                <ListItem key={this.state.cartItem.id}>
                    <ListItemAvatar>
                        <Avatar alt={this.state.cartItem.name} src={this.state.cartItem.pictureRef} variant="square"/>
                    </ListItemAvatar>
                    <ListItemText primary={this.state.cartItem.name} secondary={"$" + this.state.cartItem.price + "/kg"}/>
                    <ListItemText primary="Quantity" secondary={this.state.cartItem.quantity + "kg"}/>
                    <ListItemText primary="Total Cost" secondary={"$" + this.state.totalcost}/>
                </ListItem>
                <ListItem  key={"UpdateButton" + this.state.cartItem.id}>
                    <InputLabel>Quantity(kg)</InputLabel>
                        <Input type="number" value={this.state.quantity || ''} onChange={(e) => this.handleInputChange(e)} />
                        <Button size="small" color="primary" onClick={() => { this.handleButtonClick(this.state.cartItem.sku, this.state.quantity) }} >
                            Update Cart
                        </Button>
                        <Button size="small" color="primary" onClick={() => { this.handleDeleteButtonClick(this.state.cartItem.sku, this.state.quantity) }} >
                            Delete
                        </Button>
                </ListItem>
            </div>
        );
    }
}

export default CartItem;
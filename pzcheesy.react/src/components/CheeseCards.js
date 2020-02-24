import React, { Component } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import List from '@material-ui/core/List';
import CheeseCard from './CheeseCard.js';

export class CheeseCards extends Component {
    constructor(props) {
        super(props);

        this.state = {
            cheeses: [],
            quantityFieldValue1: 0,
            quantityFieldValue2: 0,
            totalPrice: 0
        }

        this.styles = makeStyles({
            list: {
                width: '100%',
                maxWidth: 360,
            },
            media: {
                height: 50,
            },
        });
    }

 

    componentDidMount() {
        fetch('https://localhost:5001/cheese/all')
            .then(results => {
                return results.json();
            })
            .then(data => {
                this.setState({ cheeses: data });
            })
            .catch(err => console.log(err));
    }

    render() {
        let cheeseCards = this.state.cheeses.map((cheese) => {
           return <CheeseCard cheese={cheese} addToCart={this.props.addToCart}/>
        });
        return (
            <div className={this.styles.list} >
                <List>
                    {cheeseCards}
                </List>
            </div>
        );
    }
}

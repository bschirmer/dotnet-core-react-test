import React, { Component } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import List from '@material-ui/core/List';
import Card from '@material-ui/core/Card';
import CardActionArea from '@material-ui/core/CardActionArea';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';
import { Input, InputLabel } from '@material-ui/core';

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

        this.calculateCost = this.calculateCost.bind(this);
        this.handleButtonClick = this.handleButtonClick.bind(this);
        this.handleInputChange = this.handleInputChange.bind(this);
    }

    calculateCost(value, cheese) {
        cheese.quantity = value;
        cheese.totalPrice = cheese.quantity * cheese.price;
    }

    handleButtonClick(e){
        this.props.addToCart(e.target.value);

    }

    handleInputChange(value, cheese){
        this.calculateCost(value, cheese);
    }

    componentDidMount() {
        fetch('https://localhost:5001/cheese/all')
            .then(results => {
                console.log(results);
                return results.json();
            })
            .then(data => {
                let allCheeses = data.map((cheese) => {
                    let cheesePrice;
                    if(cheese.totalPrice > 0){
                        cheesePrice=<Typography variant="body1" color="textPrimary" component="h3">
                                        ${cheese.totalPrice}
                                    </Typography>
                    }
                
                    return (
                        <Card key={cheese.sku}>
                            <CardActionArea>
                                <CardContent>
                                    <Typography gutterBottom variant="h5" component="h2">
                                        {cheese.name}
                                    </Typography>
                                    <img
                                        className={this.styles.media}
                                        src={cheese.pictureRef}
                                        height="100px"
                                    />
                                    <Typography variant="body2" color="textSecondary" component="p">
                                        Colour: {cheese.colour} <br />
                                        Flavour: {cheese.flavour} <br />
                                        Texture: {cheese.texture} <br />
                                        Aroma: {cheese.aroma} <br />
                                    </Typography>
                                    <Typography variant="body1" color="textPrimary" component="h3">
                                        ${cheese.price}/kg
                                    </Typography>
                                    {cheesePrice}
                                </CardContent>
                            </CardActionArea>
                            <CardActions>
                                <InputLabel>Quantity</InputLabel>
                                <Input type="number" onChange={(e) => this.handleInputChange(e, cheese)}/>
                                <Button size="small" color="primary" onClick={() => { this.handleButtonClick(cheese.sku) }} >
                                    Add to Cart
                                </Button>
                            </CardActions>
                        </Card>
                    )
                });
                this.setState({ cheeses: allCheeses });
            })
            .catch(err => console.log(err));
    }

    render() {
        return (
            <div className={this.styles.list} >
                <List>
                    {this.state.cheeses}
                </List>
            </div>
        );
    }
}

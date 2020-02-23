import React, { Component } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Card from '@material-ui/core/Card';
import CardActionArea from '@material-ui/core/CardActionArea';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';
import { Input, InputLabel } from '@material-ui/core';

class CheeseCard extends Component {
    constructor(props) {
        super(props);

        this.state = {
            cheese: "",
            quantityValue: null,
            totalCost: null
        }

        this.styles = makeStyles({
            media: {
                height: 50,
            },
        });

        this.calculateCost = this.calculateCost.bind(this);
        this.handleButtonClick = this.handleButtonClick.bind(this);
        this.handleInputChange = this.handleInputChange.bind(this);
    }

    componentDidMount() {
        this.setState({ cheese: this.props.cheese });
    }

    calculateCost(value, cheese) {
        cheese.quantity = value;
        cheese.totalCost = Math.round(((cheese.quantity * cheese.price) + Number.EPSILON) * 100) / 100;
        this.setState({ totalCost: cheese.totalCost });
    }

    handleButtonClick(sku, quantity) {
        if (this.state.totalCost == null || this.state.totalCost == 0) {
            this.setState({ noQuantityError: "Please enter a value" });
        } else {
            this.props.addToCart(sku, quantity);
            this.setState({ quantityValue: null });
            this.setState({ totalCost: null });
        }
    }

    handleInputChange(e, cheese) {
        this.calculateCost(e.target.value, cheese);
        this.setState({ quantityValue: e.target.value });
        this.setState({ noQuantityError: null });
    }

    render() {

        let totalCost;
        if (this.state.totalCost != null) {
            totalCost = <Typography variant="body1" color="textPrimary" component="h3">
                Total Price: {this.state.totalCost}
            </Typography>;
        }

        let noQuantityError;
        if (this.state.noQuantityError != null) {
            noQuantityError = <InputLabel>{this.state.noQuantityError}</InputLabel>
        }

        return (
            <Card key={this.state.cheese.id}>
                <CardActionArea>
                    <CardContent>
                        <Typography gutterBottom variant="h5" component="h2">
                            {this.state.cheese.name}
                        </Typography>
                        <img
                            className={this.styles.media}
                            src={this.state.cheese.pictureRef}
                            height="100px"
                        />
                        <Typography variant="body2" color="textSecondary" component="p">
                            Colour: {this.state.cheese.colour} <br />
                            Flavour: {this.state.cheese.flavour} <br />
                            Texture: {this.state.cheese.texture} <br />
                            Aroma: {this.state.cheese.aroma} <br />
                        </Typography>
                        <Typography variant="body1" color="textPrimary" component="h3">
                            ${this.state.cheese.price}/kg
                    </Typography>
                        {totalCost}
                    </CardContent>
                </CardActionArea>
                <CardActions>
                    <InputLabel>Quantity(kg)</InputLabel>
                    <Input type="number" value={this.state.quantityValue || ''} onChange={(e) => this.handleInputChange(e, this.state.cheese)} />
                    <Button size="small" color="primary" onClick={() => { this.handleButtonClick(this.state.cheese.sku, Number(this.state.quantityValue)) }} >
                        Add to Cart
                </Button>
                    {noQuantityError}
                </CardActions>
            </Card>
        );
    }
}

export default CheeseCard;
import React, { Component } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import List from '@material-ui/core/List';
import Card from '@material-ui/core/Card';
import CardActionArea from '@material-ui/core/CardActionArea';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';

export class CheeseCards extends Component {
    constructor(props) {
        super(props);

        this.state = {
            cheeses: [],
        }

        this.styles = makeStyles({
            list: {
                width: '100%',
                maxWidth: 360,
                backgroundColor: "black"
            },
            media: {
                height: 50,
            },
        });
    }

    componentDidMount() {
        fetch('/all')
            .then(results => { return results.json() })
            .then(data => {
                let allCheeses = data.map((cheese) => {
                    return (
                        <Card key={cheese.id}>
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
                                </CardContent>
                            </CardActionArea>
                            <CardActions>
                                <Button size="small" color="primary" onClick={() => { this.props.addToCart(cheese.sku) }} >
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

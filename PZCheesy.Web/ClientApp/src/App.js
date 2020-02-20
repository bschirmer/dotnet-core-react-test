import React, { Component } from 'react';
import { CheeseCard } from './components/CheeseCard';
import { Header } from './components/Header';
import { NavBar } from './components/NavBar';
import { CheeseOfTheDay } from './components/CheeseOfTheDay';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
        <div>
            <Header />
            <NavBar />
            <CheeseOfTheDay />
            <CheeseCard />
        </div>
    );
  }
}

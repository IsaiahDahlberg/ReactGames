import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Simon } from './components/Simon';
import { Home } from './components/Home';
import { Snake } from './components/Snake';
import { BlackJack } from './components/BlackJack';

export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/simon' component={Simon} />
        <Route path='/snake' component={Snake} />
        <Route path='/blackjack' component={BlackJack} />
      </Layout>
    );
  }
}

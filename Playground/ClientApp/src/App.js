import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import StarMatch from './starmatch-game/StarMatch';
import Finance from './finance/Finance';

export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/finance' component={Finance} />
        <Route path='/starmatch' component={StarMatch} />
      </Layout>
    );
  }
}

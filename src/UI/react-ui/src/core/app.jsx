import React, { Component } from 'react';
import { Switch, Route, withRouter } from "react-router-dom";
import routes from "../routes";
import { AccessDenied } from './errors'

class App extends Component {
  componentDidCatch(error) {
    if (window && error.type) {
      switch (error.type) {
        case AccessDenied: this.props.history.push('/access-denied'); break;
        default: this.props.history.push('/error'); break;
      }
    }
  }

  render() {
    return <Switch>
      {routes.map((route, i) => <Route key={i} {...route} />)}
    </Switch>
  }
}

export default withRouter(App);

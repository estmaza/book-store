import React, { Component } from 'react';

export class Error extends Component {
  render() {
    return <div>Just console.error();
    </div>
  }
}

export class AccessDenied extends Component {
  render() {
    return <div>Access Denied</div>
  }
}
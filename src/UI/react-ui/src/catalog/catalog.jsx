import React from 'react'
import { Switch, Route } from 'react-router-dom'
import ItemList from './items-list'
import ItemDetails from './item-details'

const Kits = () => (
  <Switch>
    <Route exact path={'/catalog'} component={ItemList} />
    <Route path={'/catalog/:id'} component={ItemDetails} />
  </Switch>
)

export default Kits;
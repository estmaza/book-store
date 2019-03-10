import Catalog from './catalog/catalog'
import { Error, AccessDenied } from './core/errors'

const routes = [{
  path: '/catalog',
  component: Catalog
}, {
  path: '/access-denied',
  component: AccessDenied
}, {
  path: '/error',
  component: Error
}]

export default routes;
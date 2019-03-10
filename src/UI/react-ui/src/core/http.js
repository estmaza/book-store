import { API_URL } from './config'

export const http = {
  del: url =>
    fetch(`${API_URL}${url}`, {
      method: 'DELETE',
      headers: new Headers({
        'Content-Type': 'application/json'
      }),
      credentials: 'include'
    }).then(res => res.json()),

  get: url =>
    fetch(`${API_URL}${url}`).then(res => res.json()),

  put: (url, data) =>
    fetch(`${API_URL}${url}`, {
      body: JSON.stringify(data),
      method: 'PUT',
      headers: new Headers({
        'Content-Type': 'application/json'
      }),
      credentials: 'include'
    }).then(res => res.json()),

  post: (url, data) =>
    fetch(`${API_URL}${url}`, {
      body: JSON.stringify(data),
      method: 'POST',
      headers: new Headers({
        'Content-Type': 'application/json'
      }),
      credentials: 'include'
    }).then(res => res.json())
};
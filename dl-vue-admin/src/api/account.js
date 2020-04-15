import request from '@/utils/request'

export function login(data) {
  return request({
    url: 'api/account/login',
    method: 'post',
    params: {
      username: data.username,
      password: data.password
    }
  })
}

export function getInfo() {
  return request({
    url: 'api/account/info',
    method: 'get'
  })
}

export function logout(token) {
  return request({
    url: 'api/account/logout',
    method: 'post'
  })
}

export function updatePwd(params) {
  return request({
    url: 'api/account/updatePwd',
    method: 'post',
    params
  })
}

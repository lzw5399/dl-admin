import request from '@/utils/request'

export function getList(params) {
  return request({
    url: 'api/user/list',
    method: 'get',
    params
  })
}

export function saveUser(params) {
  return request({
    url: 'api/user',
    method: 'post',
    params
  })
}

export function remove(userId) {
  return request({
    url: 'api/user',
    method: 'delete',
    params: {
      userId
    }
  })
}

export function setRole(params) {
  return request({
    url: 'api/user/setRole',
    method: 'get',
    params
  })
}

export function changeStatus(userId) {
  return request({
    url: 'api/user/changeStatus',
    method: 'get',
    params: {
      userId
    }
  })
}

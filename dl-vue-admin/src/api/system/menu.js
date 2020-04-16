import request from '@/utils/request'

export function getList() {
  return request({
    url: 'api/menu/list',
    method: 'get'
  })
}

export function listForRouter(params) {
  return request({
    url: 'api/menu/listForRouter',
    method: 'get',
    params
  })
}

export function save(params) {
  return request({
    url: 'api/menu',
    method: 'post',
    params: params
  })
}

export function delMenu(id) {
  return request({
    url: 'api/menu',
    method: 'delete',
    params: {
      id: id
    }
  })
}
export function menuTreeListByRoleId(roleId) {
  return request({
    url: 'api/menu/menuTreeListByRoleId',
    method: 'get',
    params: {
      roleId: roleId
    }
  })
}

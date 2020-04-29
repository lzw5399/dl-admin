import request from '@/utils/request'

export function getList(params) {
  return request({
    url: 'api/role/list',
    method: 'get',
    params
  })
}

export function save(params) {
  return request({
    url: 'api/role',
    method: 'post',
    params
  })
}

export function remove(roleId) {
  return request({
    url: 'api/role',
    method: 'delete',
    params: {
      roleId: roleId
    }
  })
}

export function roleTreeListByIdUser(idUser) {
  return request({
    url: 'api/role/roleTreeListByIdUser',
    method: 'get',
    params: {
      idUser: idUser
    }
  })
}

export function savePermissons(params) {
  return request({
    url: 'api/role/savePermisson',
    method: 'post',
    params
  })
}

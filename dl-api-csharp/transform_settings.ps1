$settings = get-content "Doublelives.Api/appsettings.json" | convertfrom-json;
$settings.tencentCos.appId = $env:cos_appId;
$settings.tencentCos.secretId = $env:cos_secretId;
$settings.tencentCos.secretKey = $env:cos_secretKey;
$settings.tencentCos.bucket = $env:cos_bucket;
$settings.tencentCos.region = $env:cos_region;
$settings.tencentCos.durationSecond = $env:cos_durationSecond;
$settings.tencentCos.baseUrl = $env:cos_baseUrl;
$settings.sentryClientKey = $env:sentryClientKey;
$settings.ConnectionStrings.dl = $env:conn_dl;
$settings.jwt.key = $env:jwt_key;
$settings.jwt.issuer = $env:jwt_issuer;
$settings.jwt.audience = $env:jwt_audience;
$settings.jwt.expireMinutes = $env:jwt_expireMinutes;
$settings.cache.enable = $env:cache_enable;
$settings.cache.redisconn = $env:cache_redisconn;
$settings.cache.defaultExpireMinutes = $env:cache_defaultExpireMinutes;
$settings.cors.httpOrigin = $env:cors_httpOrigin;
$settings.cors.httpsOrigin = $env:cors_httpsOrigin;
set-content "Doublelives.Api/appsettings.json" ($settings | convertto-json);
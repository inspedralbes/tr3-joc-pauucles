$IP = "204.168.215.211"
$User = "root"
$ZipName = "backend_deploy.tar.gz"

Write-Host "--- Iniciando proceso de despliegue ---" -ForegroundColor Cyan

# 1. Preparar archivos para comprimir (sin node_modules)
Write-Host "Preparando archivos..."
$StageDir = "deploy_stage"
if (Test-Path $StageDir) { Remove-Item -Path $StageDir -Recurse -Force }
New-Item -ItemType Directory -Path $StageDir -Force

# Copiamos solo lo necesario
Copy-Item -Path "backend" -Destination $StageDir -Recurse
if (Test-Path "$StageDir\backend\node_modules") { Remove-Item -Path "$StageDir\backend\node_modules" -Recurse -Force }
# NOTA: Incluimos WebGL_Build porque el usuario confirma que esta versión es la que funciona.
Copy-Item -Path "docker-compose.yml", ".env", "nginx_docker.conf" -Destination $StageDir

# Comprimir usando tar (compatible con todos los Linux)
Write-Host "Comprimiendo..."
tar -czf $ZipName -C $StageDir .
Remove-Item -Path $StageDir -Recurse -Force

# 2. Subir al servidor
Write-Host "Subiendo archivo al servidor... (Contraseña: PauUcles2026-!)"
scp $ZipName ${User}@${IP}:/root/$ZipName

# 3. Ejecutar comandos remotos
Write-Host "Ejecutando despliegue en el servidor..."
ssh ${User}@${IP} "mkdir -p /root/tr3-joc-pauucles && tar -xzf /root/$ZipName -C /root/tr3-joc-pauucles && cd /root/tr3-joc-pauucles && docker-compose down && docker-compose up --build -d"

Write-Host "--- Despliegue finalizado ---" -ForegroundColor Green
# Opcional: Limpiar local
# Remove-Item $ZipName

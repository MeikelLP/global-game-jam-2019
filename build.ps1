$unityVersion = "2019.1.0a14"

Start-Process -Wait -NoNewWindow `
-FilePath "C:\Program Files\Unity\Hub\Editor\$unityVersion\Editor\Unity.exe" `
-ArgumentList "-batchmode -quit -nographics `
  -logFile editor.log `
  -buildWindows64Player build/Application.exe"
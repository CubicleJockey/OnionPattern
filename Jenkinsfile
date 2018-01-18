pipeline {
  agent any
  stages {
    stage('Build') {
      steps {
        sh ''' def ret = sh(script:
                \'\'\'dotnet --info
				dotnet restore OnionPattern/OnionPattern.Api.csproj
				dotnet publish -c Release -o ./obj/Release OnionPattern/OnionPattern.Api.csproj\'\'\',
                returnStdout: true)
            println ret'''
      }
    }
  }
}
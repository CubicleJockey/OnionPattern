pipeline {
  agent any
  stages {
    stage('Build') {
      steps {
        def ret = bat(script:
         	'''dotnet --info 		
			dotnet restore OnionPattern/OnionPattern.Api.csproj 
			dotnet publish -c Release -o ./obj/Release OnionPattern/OnionPattern.Api.csproj''', 
                returnStdout: true) 
            println ret
      }
    }
  }
}

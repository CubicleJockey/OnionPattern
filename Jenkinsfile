pipeline {
  //Pipeline specific variables
  def app_config_path = 'Sentinel.Common.Library/Sentinel.Common.Library/'
  def env_config = 'env.EnvironmentName'
  def config = 'Release'
	
  agent any
  stages {
    stage('Build') {
      steps {
	checkout scm
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

pipeline {
    agent any
    
	branchName = env.BRANCH_NAME
	solutionName = "OnionPattern"
	solutionFileName = "${solutionName}.sln"
	nugetSources = "https://nuget.org/api/v3/"
	deployable_branches = ["master","develop"]
	
    stages {
        stage('Clean and Checkout'){  
            try { checkout scm } catch(caughtError) { deleteDir(); checkout scm }  
			
			stage('Build Artifacts'){
				bat([script: "nuget restore ${solutionFileName} -source ${nugetSources}", encoding: "UTF-8" ])
					createArtifact()
				}
			}

			def createArtifact(){
				 if(deployable_branches.contains(branchName)){
						bat([script: "\"${tool 'MSBuild'}\" ${solutionFileName} /t:Rebuild)							
				 }
				 else
				 {
					 bat([script: "\"${tool 'MSBuild'}\" ${solutionFileName} /t:Rebuild /p:IsAutoBuild=True /p:Configuration=Release", encoding: "UTF-8" ]) 
				 }
			}          
		}
	}
}

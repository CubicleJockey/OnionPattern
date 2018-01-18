pipeline {
    agent any
    stages {
        stage('build') {
            steps {
                parallel("first": {
                    echo "hello"
                },
                        "second": {
                            echo "world"
                        }
                )
            }
        }
        stage('Archive') {
            steps {
                parallel("first": {
                    echo "hello"
                },
                        "second": {
                            echo "world"
                        }
                )
            }
        }
    }
}

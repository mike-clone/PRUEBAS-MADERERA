SonarScanner.MSBuild.exe begin /k:"maderera" /d:sonar.login="squ_957502e783d65f59fd8471b59e1b5c1d9cca199f" /d:sonar.host.url="https://sonarqube.bit2bitamericas.com"

 MSBuild.exe PruebasMaderera.sln

SonarScanner.MSBuild.exe end /d:sonar.login="squ_957502e783d65f59fd8471b59e1b5c1d9cca199f" 
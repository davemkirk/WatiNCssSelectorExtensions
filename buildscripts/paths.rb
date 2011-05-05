root_folder = File.expand_path("#{File.dirname(__FILE__)}/..")

Folders = {
  :root => root_folder,
  :src => "src",
  :out => "build",
  :tests => File.join("build", "tests"),
  :tools => "tools",
  :nunit => File.join("tools", "NUnit", "bin"),
  
  :packages => "packages",
  :nuspec => File.join("build", "nuspec", Projects[:proj_key][:dir]),
  :nuget => File.join("build", "nuget"),
  
  :proj_key_out => 'placeholder - specify build environment',
  :proj_key_test_out => 'placeholder - specify build environment',
  :binaries => "placeholder - specify build environment"
}

Files = {
  :sln => "WatinCssSelectorExtensions.sln",
  :version => "VERSION",
  
  :proj_key => {
    :nuspec => File.join(Folders[:nuspec], "#{Projects[:proj_key][:id]}.nuspec"),
	:test_log => File.join(Folders[:tests], "WatiNCssSelectorExtensions.log"),
	:test_xml => File.join(Folders[:tests], "WatiNCssSelectorExtensions.xml"),
	:test => 'ex: WatiNCssSelectorExtensions.Tests.dll'
  }
}

Commands = {
  :nunit => File.join(Folders[:nunit], "nunit-console.exe"),
  :nuget => File.join(Folders[:tools], "NuGet.exe"),
  :ilmerge => File.join(Folders[:tools], "ILMerge.exe")
}
function translatePathProtocol(pathToTranslate){
  if(pathToTranslate.includes("://")){
    var protocol = pathToTranslate.substr(0,pathToTranslate.indexOf(':'));
    var after = pathToTranslate.substr(pathToTranslate.indexOf('/')+2);
    var appDataPath = Globals.AppDataPath;
    if(appDataPath.endsWith(Globals.PlatformPathSeperator)){
      appDataPath = appDataPath.substring(0, appDataPath.length - 1);
    }
    switch (protocol.toLowerCase()) {
      case "home":
        return appDataPath + after;
        break;
      case "addons":
        return appDataPath + Globals.PlatformPathSeperator + "Addons" + after;
      case "system":
        return appDataPath + Globals.PlatformPathSeperator + "System" + after;
      case "temp":
        return appDataPath + Globals.PlatformPathSeperator + "Temp" + after;
      case "user":
        return appDataPath + Globals.PlatformPathSeperator + "UserData" + after;
      case "userdata":
        return appDataPath + Globals.PlatformPathSeperator + "UserData" + after;
      default:
        return pathToTranslate;
    }
  }
  return pathToTranslate;
}

export const Path = {
  combine(){
    var params = Array.prototype.slice.call(arguments);
    if(params.length <= 1){
      return "";
    }
    var last = params.pop();
    var combined = params.shift();
    params.forEach((item, i) => {
      combined += Globals.PlatformPathSeperator + item;
    });
    if(last.includes(".")){
      combined +=  Globals.PlatformPathSeperator + last;
    } else {
      combined += Globals.PlatformPathSeperator + last + Globals.PlatformPathSeperator;
    }
    return translatePathProtocol(combined);
  },

  getUrlHostName(url){
    var urlResult;
    var match;
    if (match = url.match(/^(?:https?:\/\/)?(?:[^@\n]+@)?(?:www\.)?([^:\/\n\?\=]+)/im)) {
      urlResult = match[1];
      if (match = urlResult.match(/^[^\.]+\.(.+\..+)$/)) {
          urlResult = match[1];
      }
    }
    if(urlResult.includes(".")){
      return urlResult.split(".")[0];
    }
    return urlResult
  }
}

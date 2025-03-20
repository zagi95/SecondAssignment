window.getBrowserInfo = () => {
    const userAgent = navigator.userAgent;
    let browserName = "None";
    if (userAgent.includes('Firefox')) {
        browserName = 'Firefox';
    }
    
    return `${browserName}`;
}
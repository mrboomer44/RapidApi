// RapidAPI Dashboard Client Script

document.addEventListener('DOMContentLoaded', () => {
    // 1. Live Clock
    function updateClock() {
        const now = new Date();
        const timeStr = now.toLocaleTimeString('tr-TR', { hour: '2-digit', minute: '2-digit', second: '2-digit' });
        const dateStr = now.toLocaleDateString('tr-TR', { day: 'numeric', month: 'long', year: 'numeric', weekday: 'short' });
        
        const clockEl = document.getElementById('clockText');
        const dateEl = document.getElementById('dateText');
        
        if (clockEl) clockEl.textContent = timeStr;
        if (dateEl) dateEl.textContent = dateStr;
    }
    
    updateClock();
    setInterval(updateClock, 1000);

    // 2. Play / Pause Music Toggle
    const playBtn = document.getElementById('playPauseBtn');
    const playIcon = document.getElementById('playIcon');
    let isPlaying = false;

    if (playBtn && playIcon) {
        playBtn.addEventListener('click', () => {
            isPlaying = !isPlaying;
            if (isPlaying) {
                playIcon.className = 'fa-solid fa-pause';
                showToast('🎵 Duman - Kafama Göre çalınıyor...');
            } else {
                playIcon.className = 'fa-solid fa-play';
                showToast('⏸️ Müzik duraklatıldı.');
            }
        });
    }

    // 3. Copy Quote
    const copyQuoteBtn = document.getElementById('copyQuoteBtn');
    if (copyQuoteBtn) {
        copyQuoteBtn.addEventListener('click', () => {
            const quoteText = document.getElementById('quoteText')?.textContent.trim() || '';
            const quoteAuthor = document.getElementById('quoteAuthor')?.textContent.trim() || '';
            const fullText = `"${quoteText}" - ${quoteAuthor}`;
            
            navigator.clipboard.writeText(fullText).then(() => {
                showToast('✨ Motivasyon sözü panoya kopyalandı!');
            });
        });
    }
});

function showToast(message) {
    let toast = document.getElementById('simpleToast');
    if (!toast) {
        toast = document.createElement('div');
        toast.id = 'simpleToast';
        toast.className = 'simple-toast';
        document.body.appendChild(toast);
    }
    
    toast.innerHTML = message;
    toast.style.display = 'block';
    
    setTimeout(() => {
        toast.style.display = 'none';
    }, 2800);
}

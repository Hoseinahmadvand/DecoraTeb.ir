// ================= Navbar Scroll =================
const nav = document.getElementById('mainNav');
const backTop = document.getElementById('backTop');

window.addEventListener('scroll', () => {
    nav?.classList.toggle('scrolled', window.scrollY > 40);
    backTop?.classList.toggle('show', window.scrollY > 500);
});

backTop?.addEventListener('click', () => {
    window.scrollTo({
        top: 0,
        behavior: 'smooth'
    });
});

// ================= Mobile Menu =================
document.querySelectorAll('#navMenu .nav-link').forEach(link => {
    link.addEventListener('click', () => {
        const menu = document.getElementById('navMenu');

        if (menu?.classList.contains('show')) {
            bootstrap.Collapse.getOrCreateInstance(menu).hide();
        }
    });
});

// ================= Scroll Reveal =================
const reveals = document.querySelectorAll('.reveal');

if (reveals.length) {

    const revealObserver = new IntersectionObserver(entries => {

        entries.forEach(entry => {

            if (entry.isIntersecting) {
                entry.target.classList.add('in');
                revealObserver.unobserve(entry.target);
            }

        });

    }, {
        threshold: 0.15
    });

    reveals.forEach(el => revealObserver.observe(el));

}

// ================= Counter Animation =================
const counters = document.querySelectorAll('.stat-num');

if (counters.length) {

    const counterObserver = new IntersectionObserver(entries => {

        entries.forEach(entry => {

            if (!entry.isIntersecting) return;

            const el = entry.target;
            const target = parseInt(el.dataset.count, 10);

            let current = 0;
            const step = Math.max(1, Math.round(target / 50));

            const timer = setInterval(() => {

                current += step;

                if (current >= target) {
                    current = target;
                    clearInterval(timer);
                }

                el.textContent = current.toLocaleString('fa-IR');

            }, 25);

            counterObserver.unobserve(el);

        });

    }, {
        threshold: 0.5
    });

    counters.forEach(c => counterObserver.observe(c));

}

// ================= Card 3D Tilt =================
const tiltCards = document.querySelectorAll('.tilt-card');
const reduceMotion = window.matchMedia('(prefers-reduced-motion: reduce)').matches;

if (!reduceMotion) {

    tiltCards.forEach(card => {

        card.addEventListener('mousemove', e => {

            const rect = card.getBoundingClientRect();

            const x = e.clientX - rect.left;
            const y = e.clientY - rect.top;

            const rotateX = ((y / rect.height) - 0.5) * -12;
            const rotateY = ((x / rect.width) - 0.5) * 12;

            card.style.transform =
                `perspective(900px)
                rotateX(${rotateX}deg)
                rotateY(${rotateY}deg)
                translateY(-4px)`;

        });

        card.addEventListener('mouseleave', () => {

            card.style.transform =
                'perspective(900px) rotateX(0) rotateY(0) translateY(0)';

        });

    });

}
// ================= Hero Slider =================
(() => {

    const slides = document.querySelectorAll('.hs-slide');
    if (!slides.length) return;

    const dashes = document.querySelectorAll('.hs-dash');
    const counter = document.getElementById('hsCurrent');
    const prev = document.getElementById('hsPrev');
    const next = document.getElementById('hsNext');

    const faNums = ['۰۱', '۰۲', '۰۳', '۰۴', '۰۵', '۰۶'];

    let current = 0;
    let timer;

    function goTo(index) {

        slides[current].classList.remove('active');
        dashes[current]?.classList.remove('active');

        current = (index + slides.length) % slides.length;

        slides[current].classList.add('active');
        dashes[current]?.classList.add('active');

        counter && (counter.textContent = faNums[current]);

    }

    const start = () => {
        timer = setInterval(() => goTo(current + 1), 6000);
    };

    const restart = () => {
        clearInterval(timer);
        start();
    };

    next?.addEventListener('click', () => {
        goTo(current + 1);
        restart();
    });

    prev?.addEventListener('click', () => {
        goTo(current - 1);
        restart();
    });

    dashes.forEach(d =>
        d.addEventListener('click', () => {
            goTo(+d.dataset.goto);
            restart();
        })
    );

    const slider = document.querySelector('.hero-slider');

    slider?.addEventListener('mouseenter', () => clearInterval(timer));
    slider?.addEventListener('mouseleave', start);

    start();

})();

// ================= Filter =================
const filterBtns = document.querySelectorAll('.filter-pills .btn');
const filterItems = document.querySelectorAll('.project-item');

filterBtns.forEach(btn => {

    btn.addEventListener('click', () => {

        filterBtns.forEach(b => b.classList.remove('active'));
        btn.classList.add('active');

        const filter = btn.dataset.filter;

        filterItems.forEach(item => {
            item.classList.toggle(
                'project-hidden',
                !(filter === 'all' || item.dataset.cat === filter)
            );
        });

    });

});

// ================= Contact Form =================
const form = document.getElementById('contactForm');

if (form) {

    form.addEventListener('submit', e => {

        e.preventDefault();

        if (!form.checkValidity()) {
            form.reportValidity();
            return;
        }

        document.getElementById('formSuccess')
            ?.classList.remove('d-none');

        form.querySelectorAll('input, textarea, select')
            .forEach(el => el.disabled = true);

        const btn = form.querySelector('button[type="submit"]');

        if (btn) {

            btn.textContent = 'در حال ارسال...';

            setTimeout(() => {
                btn.textContent = 'درخواست ارسال شد ✓';
            }, 600);

        }

    });

}
// ================= Newsletter =================
document.querySelectorAll('.newsletter-band form').forEach(form => {

    form.addEventListener('submit', e => {

        e.preventDefault();

        const btn = form.querySelector('button');

        if (btn) {
            btn.textContent = 'عضو شدید ✓';
            btn.disabled = true;
        }

    });

});

// ================= Pagination =================
document.querySelectorAll('.pagination-custom button').forEach(btn => {

    btn.addEventListener('click', () => {

        if (isNaN(parseInt(btn.textContent))) return;

        document
            .querySelectorAll('.pagination-custom button')
            .forEach(item => item.classList.remove('active'));

        btn.classList.add('active');

        document.getElementById('blogGrid')?.scrollIntoView({
            behavior: 'smooth',
            block: 'start'
        });

    });

});
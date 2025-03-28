
    window.chartRegistry = { };

        window.createChartWithCanvasId = (canvasId, labels, payInData, payOutData, unpaidWinsData, title) => {
            // Destroy existing chart if it exists
            if (window.chartRegistry[canvasId]) {
        window.chartRegistry[canvasId].destroy();
    delete window.chartRegistry[canvasId];
            }

    const canvas = document.getElementById(canvasId);
    if (!canvas) {
        console.error('Could not find canvas element');
    return;
            }

    const ctx = canvas.getContext('2d');

    // Create new chart
    const chart = new Chart(ctx, {
        type: 'bar',
    data: {
        labels: labels,
    datasets: [
    {
        label: 'Pay In',
    data: payInData,
    backgroundColor: 'rgba(33, 102, 172, 0.6)'
                        },
    {
        label: 'Pay Out',
    data: payOutData,
    backgroundColor: 'rgba(102, 194, 165, 0.6)'
                        },
    {
        label: 'Unpaid Wins',
    data: unpaidWinsData,
    backgroundColor: 'rgba(253, 141, 60, 0.6)'
                        }
    ]
                },
    options: {
        responsive: true,
    maintainAspectRatio: false,
    plugins: {
        title: {
        display: true,
    text: title
                        },
    tooltip: {
        mode: 'index',
    intersect: false
                        }
                    },
    scales: {
        x: {
        stacked: true,
    title: {
        display: true,
    text: 'Locations'
                            }
                        },
    y: {
        stacked: true,
    title: {
        display: true,
    text: 'Amount'
                            }
                        }
                    }
                }
            });

    // Store the chart in the registry
    window.chartRegistry[canvasId] = chart;
        };

        window.createPieChart = (canvasId, labels, values, title) => {
            // Destroy existing chart if it exists
            if (window.chartRegistry[canvasId]) {
        window.chartRegistry[canvasId].destroy();
    delete window.chartRegistry[canvasId];
            }

    const canvas = document.getElementById(canvasId);

    if (!canvas) {
        console.error('Canvas not found:', canvasId);
    return;
            }

    const ctx = canvas.getContext('2d');

    const backgroundColors = { }; // Use an object literal

            if (values && values.length > 0) {
        backgroundColors[values[0]] = 'rgba(33, 102, 172, 0.8)';
            }
            if (values && values.length > 1) {
        backgroundColors[values[1]] = 'rgba(102, 194, 165, 0.8)';
            }
            if (values && values.length > 2) {
        backgroundColors[values[2]] = 'rgba(253, 141, 60, 0.8)';
            }

            const finalColors = values.map(value => backgroundColors[value] || 'rgba(0, 0, 0, 0.1)');

    // Create pie chart
    const chart = new Chart(ctx, {
        type: 'pie',
    data: {
        labels: labels,
    datasets: [{
        data: values,
    backgroundColor: finalColors
                    }]
                },
    options: {
        responsive: true,
    maintainAspectRatio: false,
    plugins: {
        title: {
        display: true,
    text: title
                        },
    legend: {
        position: 'bottom'
                        }
                    }
                }
            });

    // Store the chart in the registry
    window.chartRegistry[canvasId] = chart;
        };
